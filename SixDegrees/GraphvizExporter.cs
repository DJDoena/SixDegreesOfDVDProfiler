using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using mitoSoft.Graphs;
using mitoSoft.Graphs.GraphVizInterop;

namespace DoenaSoft.DVDProfiler.SixDegreesOfDVDProfiler
{
    internal sealed class GraphvizExporter
    {
        private readonly ImageRenderer _renderer;

        private DirectedGraph _resultGraph;

        private bool _withJobs;

        public GraphvizExporter(string graphvizPath)
        {
            _renderer = new ImageRenderer(graphvizPath);
        }

        public void SaveImage(DirectedGraph resultGraph, bool withJobs)
        {
            _resultGraph = resultGraph;

            _withJobs = withJobs;

            try
            {
                this.TrySaveImage();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unexpected error: {ex.Message}", "GraphWiz", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TrySaveImage()
        {
            using (var sfd = new SaveFileDialog()
            {
                CheckPathExists = true,
                Filter = "Portable Network Graphic (PNG)|*.png|Scalable Vector Graphics (SVG)|*.svg|Bitmap (BMP)|*.bmp|Tagged Image File Format (TIFF)|*.tiff|JPEG|*.jpg|Graphics Interchange Format (GIF)|*.gif",
                OverwritePrompt = true,
                RestoreDirectory = true,
                ValidateNames = true,
            })
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    this.SaveImage(new FileInfo(sfd.FileName));
                }
            }
        }

        private void SaveImage(FileInfo fileInfo)
        {
            this.AddDescriptions();

            if (this.Render(fileInfo))
            {
                Process.Start(fileInfo.FullName);
            }
        }

        private void AddDescriptions()
        {
            foreach (var node in _resultGraph.Nodes)
            {
                if (node.Tag is PersonNode personNode)
                {
                    node.Description = PersonFormatter.GetName(personNode.Person).Replace("\"", "'");
                }
                else if (node.Tag is ProfileNode profileNode)
                {
                    node.Description = profileNode.Profile.Title.Replace("\"", "'");
                }
            }

            foreach (var edge in _resultGraph.Edges)
            {
                if (_withJobs)
                {
                    PersonNode personNode;
                    ProfileNode profileNode;
                    if (edge.Source.Tag is PersonNode temp)
                    {
                        personNode = temp;
                        profileNode = (ProfileNode)edge.Target.Tag;
                    }
                    else
                    {
                        personNode = (PersonNode)edge.Target.Tag;
                        profileNode = (ProfileNode)edge.Source.Tag;
                    }

                    var jobs = personNode.GetJobs(profileNode);

                    edge.Description = PersonFormatter.GetJob(jobs.First()).Replace("\"", "'");
                }
                else
                {
                    edge.Description = string.Empty;
                }
            }
        }

        private bool Render(FileInfo fileInfo)
        {
            var dotText = _resultGraph.ToDotText();

            if (fileInfo.Extension.ToLower() == ".svg")
            {
                _renderer.RenderImage(dotText, fileInfo.FullName, mitoSoft.Graphs.GraphVizInterop.Enums.LayoutEngine.dot, mitoSoft.Graphs.GraphVizInterop.Enums.ImageFormat.svg);

                return true;
            }

            mitoSoft.Graphs.GraphVizInterop.Enums.ImageFormat renderFormat;
            System.Drawing.Imaging.ImageFormat imageFormat;
            switch (fileInfo.Extension.ToLower())
            {
                case ".png":
                    {
                        renderFormat = mitoSoft.Graphs.GraphVizInterop.Enums.ImageFormat.png;

                        imageFormat = System.Drawing.Imaging.ImageFormat.Png;

                        break;
                    }
                case ".bmp":
                    {
                        renderFormat = mitoSoft.Graphs.GraphVizInterop.Enums.ImageFormat.png;

                        imageFormat = System.Drawing.Imaging.ImageFormat.Bmp;

                        break;
                    }
                case ".tif":
                case ".tiff":
                    {
                        renderFormat = mitoSoft.Graphs.GraphVizInterop.Enums.ImageFormat.png;

                        imageFormat = System.Drawing.Imaging.ImageFormat.Tiff;

                        break;
                    }
                case ".jpg":
                case ".jpeg":
                    {
                        renderFormat = mitoSoft.Graphs.GraphVizInterop.Enums.ImageFormat.jpg;

                        imageFormat = System.Drawing.Imaging.ImageFormat.Jpeg;

                        break;
                    }
                case ".gif":
                    {
                        renderFormat = mitoSoft.Graphs.GraphVizInterop.Enums.ImageFormat.png;

                        imageFormat = System.Drawing.Imaging.ImageFormat.Gif;

                        break;
                    }
                default:
                    {
                        MessageBox.Show($"Unknown file format: {fileInfo.Extension}", "GraphWiz", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        return false;
                    }
            }

            var image = _renderer.RenderImage(dotText, mitoSoft.Graphs.GraphVizInterop.Enums.LayoutEngine.dot, renderFormat);

            image.Save(fileInfo.FullName, imageFormat);

            return true;
        }
    }
}