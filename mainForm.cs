using Project4.GraphicObjects;
using Project4.GraphicObjects.Enums;
using Project4.GraphicObjects.Figures;
using Project4.GraphicObjects.Objects3D;
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
        private readonly List<BaseCuboid> _cuboids = new List<BaseCuboid>();
        private BasePolygon _selectedPolygon;
        private BaseCuboid _selectedCuboid;
        private State _currentState;
        private Graphics _graphics;
        private Point _position;
        public mainForm()
        {
            InitializeComponent();
            _graphics = mainPictureBox.CreateGraphics();
        }

        private void addButton_MouseDown(object sender, MouseEventArgs e)
        {
            switch (_currentState)
            {
                case State.NewFigure:
                    {
                        if (_selectedPolygon != null)
                        {
                            _polygons.Add(_selectedPolygon);
                            _selectedPolygon = null;
                            _currentState = State.Default;
                        }
                        break;
                    }
                case State.NewCuboid:
                    {
                        if (_selectedCuboid != null)
                        {
                            _cuboids.Add(_selectedCuboid);
                            _selectedCuboid = null;
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

            if (_selectedCuboid != null)
                _cuboids.Remove(_selectedCuboid);

            _selectedPolygon = null;
            _selectedCuboid = null;
            _currentState = State.Default;
        }

        private void createPolygonButton_MouseDown(object sender, MouseEventArgs e)
        {
            _selectedPolygon = new ConcretePolygon(_graphics);
            _currentState = State.NewFigure;
        }

        private void createCuboidButton_MouseDown(object sender, MouseEventArgs e)
        {
            _selectedCuboid = new ConcreteCuboid(_graphics);
            _currentState = State.NewCuboid;
        }

        private void mainPictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            var _position = new Point(e.X, e.Y);
            switch (_currentState)
            {
                case State.Default:
                    {
                        SelectObject(_position);
                        break;
                    }
                case State.NewFigure:
                    {
                        if (_selectedPolygon != null)
                        {
                            var vertice = new Vertice(_position, _graphics);
                            _selectedPolygon.AddVertice(vertice);
                        }
                        break;
                    }
                case State.NewCuboid:
                    {
                        if (_selectedCuboid != null)
                        {
                            var vertice = new Vertice(_position, _graphics);
                            _selectedCuboid.AddVertice(vertice);
                        }
                        break;
                    }
            }

            if (_currentState != State.Default)
                DrawAllShapes();
        }

        private void mainPictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            var position = new Point(e.X, e.Y);
            switch (_currentState)
            {
                case State.Move:
                    {
                        if (_selectedCuboid != null)
                        {
                            _selectedCuboid.Move(_position, position);
                        }
                        else if (_selectedPolygon != null)
                        {
                            _selectedPolygon.Move(_position, position);
                        }
                        DrawAllShapes();
                        break;
                    }
            }
            _position = position;
        }

        private void mainPictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            switch (_currentState)
            {
                case State.Move:
                    {
                        _currentState = State.Default;
                        _selectedCuboid = null;
                        _selectedPolygon = null;
                        break;
                    }
            }
        }

        private void SelectObject(Point position)
        {
            foreach (var cuboid in _cuboids)
            {
                if (cuboid.CheckIfClicked(position))
                {
                    _selectedCuboid = cuboid;
                    _currentState = State.Move;
                    return;
                }
            }

            foreach (var polygon in _polygons)
            {
                if (polygon.CheckIfClicked(position))
                {
                    _selectedPolygon = polygon;
                    _currentState = State.Move;
                    return;
                }
            }
        }

        private void SetGraphics()
        {
            _graphics = mainPictureBox.CreateGraphics();
            foreach (var polygon in _polygons)
                polygon.SetGraphics(_graphics);

            foreach (var cuboid in _cuboids)
                cuboid.SetGraphics(_graphics);

            if (_selectedPolygon != null)
                _selectedPolygon.SetGraphics(_graphics);

            if (_selectedCuboid != null)
                _selectedCuboid.SetGraphics(_graphics);
        }

        private void DrawAllShapes()
        {
            SetGraphics();
            _graphics.Clear(Color.White);
            foreach (var polygon in _polygons)
                polygon.Draw();

            foreach (var cuboid in _cuboids)
                cuboid.Draw();

            if (_selectedPolygon != null)
                _selectedPolygon.Draw();

            if (_selectedCuboid != null)
                _selectedCuboid.Draw();
        }
    }
}
