using Project4.GraphicObjects;
using Project4.GraphicObjects.Enums;
using Project4.GraphicObjects.Figures;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project4
{
    public partial class mainForm : Form
    {
        private readonly List<BasePolygon> _polygons = new List<BasePolygon>();
        private BasePolygon _selectedPolygon;
        private State _currentState;
        private Graphics _graphics;
        public mainForm()
        {
            InitializeComponent();
            _graphics = mainPictureBox.CreateGraphics();
        }

        private void addButton_MouseDown(object sender, MouseEventArgs e)
        {
            switch (_currentState)
            {
                case State.NewShape:
                    {
                        if (_selectedPolygon != null)
                        {
                            _polygons.Add(_selectedPolygon);
                            _selectedPolygon = null;
                            _currentState = State.Default;
                        }
                        break;
                    }
            }
            DrawAllShapes();
        }

        private void deleteButton_MouseDown(object sender, MouseEventArgs e)
        {
            if (_selectedPolygon != null)
                _polygons.Remove(_selectedPolygon);
            _currentState = State.Default;
        }

        private void createButton_MouseDown(object sender, MouseEventArgs e)
        {
            _selectedPolygon = new ConcretePolygon();
            _selectedPolygon.Graphics = _graphics;
            _currentState = State.NewShape;
        }

        private void mainPictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            var position = new Point(e.X, e.Y);
            switch (_currentState)
            {
                case State.NewShape:
                    {
                        if (_selectedPolygon != null)
                        {
                            var vertice = new Vertice(position);
                            vertice.Graphics = _graphics;
                            _selectedPolygon.AddVertice(vertice);
                        }
                        break;
                    }
            }
            DrawAllShapes();
        }

        private void DrawAllShapes()
        {
            _graphics.Clear(Color.White);
            foreach (var polygon in _polygons)
            {
                polygon.Draw();
            }

            if (_selectedPolygon != null)
                _selectedPolygon.Draw();
        }
    }
}
