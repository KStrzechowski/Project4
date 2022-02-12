using Project4.Data;
using Project4.Data.Structures;
using Project4.GraphicObjects;
using Project4.GraphicObjects.Enums;
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
        private List<BaseObject3D> _objects3D = new();
        private List<bool> _objectsState = new();
        private Camera _currentCamera;
        private Camera _camera1;
        private Camera _camera2;
        private Camera _camera3;
        private bool[] _cameraStates = new bool[3];
        private State _state;

        public mainForm()
        {
            InitializeComponent();

            SetBitmap();
            initializeCameras();
            initializeObjects();
        }

        private void initializeCameras()
        {
            CustomVector vector1 = new CustomVector(new double[] { 0, 0, 0 });
            CustomVector vector2 = new CustomVector(new double[] { 0, 0, 1 });
            _camera1 = new Camera(vector1, vector2);

            vector1 = new CustomVector(new double[] { 80, 0, 0 });
            vector2 = new CustomVector(new double[] { 0, 0, 20 });
            _camera2 = new Camera(vector1, vector2);

            vector1 = new CustomVector(new double[] { 0, 50, 0 });
            vector2 = new CustomVector(new double[] { 30, 0, 0 });
            _camera3 = new Camera(vector1, vector2);

            _state = State.FirstCamera;
            _currentCamera = _camera1;
        }

        private void initializeObjects()
        {
            //_objects3D.Add(new Diamond(_currentCamera, new CustomVector( new double[]{ 0, 0, 40, 1 }), 5));
            //_objectsState.Add(true);
            _objects3D.Add(new Sphere(_currentCamera, new CustomVector(new double[] { 0, 0, 40, 1 }), 5));
            _objectsState.Add(true);

            _objects3D.Add(new Diamond(_currentCamera, new CustomVector(new double[] { -5, 15, 180, 1 }), 5));
            _objectsState.Add(true);

            _objects3D.Add(new Diamond(_currentCamera, new CustomVector(new double[] { 7, -15, 30, 1 }), 5));
            _objectsState.Add(true);
        }

        private void SetBitmap()
        {
            mainPictureBox.Image = new Bitmap(mainPictureBox.Width, mainPictureBox.Height);
            BaseGraphicObject.Bitmap = (Bitmap)mainPictureBox.Image;
            BaseGraphicObject.Graphics = Graphics.FromImage(mainPictureBox.Image);
            BaseGraphicObject.ScreenWidth = BaseGraphicObject.Bitmap.Width;
            BaseGraphicObject.ScreenHeight = BaseGraphicObject.Bitmap.Height;
            BaseGraphicObject.ZBuffor = new double[BaseGraphicObject.ScreenWidth + 1, BaseGraphicObject.ScreenHeight];
            for (int i = 0; i <= BaseGraphicObject.ScreenWidth; i++)
            {
                for (int j = 0; j < BaseGraphicObject.ScreenHeight; j++)
                {
                    BaseGraphicObject.ZBuffor[i, j] = int.MaxValue; 
                }
            }
        }

        private void DrawAllShapes()
        {
            SetBitmap();
            foreach (var object3D in _objects3D)
                object3D.Draw();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            MoveCamera();
            MoveObjects();
            DrawAllShapes();
        }

        private void MoveObjects()
        {
            CustomVector vector;
            var figure = _objects3D[0];
            if (figure.points[0][2] >= 80)
                _objectsState[0] = false;
            else if (figure.points[0][2] <= 20)
                _objectsState[0] = true;
        
            if (_objectsState[0])
                vector = new CustomVector(new double[] { 0, 0, 0.1 });
            else
                vector = new CustomVector(new double[] { 0, 0, -0.1 });
            figure.Translation(vector);
            figure.RotateZ(0.01);
        }

        private void MoveCamera()
        {
            switch (_state)
            {
                case State.SecondCamera:
                    {
                        MoveSecondCamera();
                        break;
                    }
                case State.ThirdCamera:
                    {
                        MoveThirdCamera();
                        break;
                    }
            }
        }

        private void MoveSecondCamera()
        {
            _currentCamera = _camera2;
            if (_currentCamera.Position[2] >= 120)
                _cameraStates[1] = true;
            else if (_currentCamera.Position[2] <= 15)
                _cameraStates[1] = false;

            if (!_cameraStates[1])
                _camera2.ChangePosition(new CustomVector(new double[] 
                { _currentCamera.Position[0], _currentCamera.Position[1], _currentCamera.Position[2] + 0.1 }));
            else
                _camera2.ChangePosition(new CustomVector(new double[] 
                { _currentCamera.Position[0], _currentCamera.Position[1], _currentCamera.Position[2] - 0.1 }));
            
            SetNewCamera(_camera2);
        }

        private void MoveThirdCamera()
        {
            _currentCamera = _camera3;

            var diamond = _objects3D[0];
            var center = new CustomVector(new double[] { diamond.center[0], diamond.center[1], diamond.center[2] });
            _camera3.ChangeTarget(center);
            SetNewCamera(_camera3);
        }

        private void SetNewCamera(Camera camera)
        {
            _currentCamera = camera;
            foreach (var object3D in _objects3D)
                object3D.ChangeCamera(_currentCamera);
        }

        private void SetState(State state)
        {
            _state = state;
        }

        private void mainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.D1 && _state != State.FirstCamera)
            {
                SetNewCamera(_camera1);
                SetState(State.FirstCamera);
            }
            else if (e.KeyCode == Keys.D2 && _state != State.SecondCamera)
            {
                SetNewCamera(_camera2);
                SetState(State.SecondCamera);
            }
            else if (e.KeyCode == Keys.D3 && _state != State.ThirdCamera)
            {
                SetNewCamera(_camera3);
                SetState(State.ThirdCamera);
            }
        }
    }
}
