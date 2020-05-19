using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using AForge;
using AForge.Imaging.Filters;
using AForge.Math;
using AForge.Math.Geometry;
using AForge.Video;
using AForge.Video.DirectShow;
using AForge.Vision.GlyphRecognition;
using Xna3DViewer;



namespace angeldetector
{
    public partial class Form1 : Form
    {
        #region kalmanFilter
        KalmanFilter KARoll;
        KalmanFilter KAPitch;
        KalmanFilter KAYaw;

        KalmanFilter KBRoll;
        KalmanFilter KBPitch;
        KalmanFilter KBYaw;


        KalmanFilter KCRoll;
        KalmanFilter KCPitch;
        KalmanFilter KCYaw;

        List<double> aListRoll;
        List<double> aListPitch;
        List<double> aListYaw;
        List<double> bListRoll;
        List<double> bListPitch;
        List<double> bListYaw;
        List<double> cListRoll;
        List<double> cListPitch;
        List<double> cListYaw;


        //Accord.Statistics.Running.KalmanFilter2D kfA1 = new Accord.Statistics.Running.KalmanFilter2D();
        //Accord.Statistics.Running.KalmanFilter2D kfA2 = new Accord.Statistics.Running.KalmanFilter2D();
        //Accord.Statistics.Running.KalmanFilter2D kfA3 = new Accord.Statistics.Running.KalmanFilter2D();
        //Accord.Statistics.Running.KalmanFilter2D kfA4 = new Accord.Statistics.Running.KalmanFilter2D();
        //Accord.Statistics.Running.KalmanFilter2D kfB1 = new Accord.Statistics.Running.KalmanFilter2D();
        //Accord.Statistics.Running.KalmanFilter2D kfB2 = new Accord.Statistics.Running.KalmanFilter2D();
        //Accord.Statistics.Running.KalmanFilter2D kfB3 = new Accord.Statistics.Running.KalmanFilter2D();
        //Accord.Statistics.Running.KalmanFilter2D kfB4 = new Accord.Statistics.Running.KalmanFilter2D();
        //Accord.Statistics.Running.KalmanFilter2D kfC1 = new Accord.Statistics.Running.KalmanFilter2D();
        //Accord.Statistics.Running.KalmanFilter2D kfC2 = new Accord.Statistics.Running.KalmanFilter2D();
        //Accord.Statistics.Running.KalmanFilter2D kfC3 = new Accord.Statistics.Running.KalmanFilter2D();
        //Accord.Statistics.Running.KalmanFilter2D kfC4 = new Accord.Statistics.Running.KalmanFilter2D();

        #endregion
        #region Configuration Option Names
        private const string activeDatabaseOption = "ActiveDatabase";
        private const string mainFormXOption = "MainFormX";
        private const string mainFormYOption = "MainFormY";
        private const string mainFormWidthOption = "MainFormWidth";
        private const string mainFormHeightOption = "MainFormHeight";
        private const string mainFormStateOption = "MainFormState";
        private const string mainSplitterOption = "MainSplitter";
        private const string glyphSizeOption = "GlyphSize";
        private const string focalLengthOption = "FocalLength";
        private const string detectFocalLengthOption = "DetectFocalLength";
        private const string autoDetectFocalLengthOption = "AutoDetectFocalLength";
        float pich1 = 0, pich2 = 0, roll1 = 0, roll2 = 0;
        #endregion
        private AugmentedRealityForm arForm = null;
        private const string ErrorBoxTitle = "Error";
        private string activeGlyphDatabaseName = null;
        private bool autoDetectFocalLength = true;
        private ImageList glyphsImageList = new ImageList();
        private GlyphDatabases glyphDatabases = new GlyphDatabases();
        private GlyphDatabase activeGlyphDatabase = null;
        private GlyphImageProcessor imageProcessor = new GlyphImageProcessor();
        private Stopwatch stopWatch = null;
        private object sync = new object();
        private object sync2 = new object();
        AForge.Math.Matrix3x3 matrixA;
        AForge.Math.Matrix3x3 matrixB;
        AForge.Math.Matrix3x3 matrixC;
        FileStream fs;
        bool Write = false;
        float yawa = 500, pitcha = 500, rolla = 500;
        float yawb = 500, pitchb = 500, rollb = 500;
        float yawc = 500, pitchc = 500, rollc = 500;
        #region Poset
        // model points
        private AForge.Math.Vector3[] modelPoints = new AForge.Math.Vector3[4];
        private readonly AForge.Point emptyPoint = new AForge.Point(-30000, -30000);

        // image point of the object to estimate pose for
        private AForge.Point[] imagePoints = new AForge.Point[4];

        // camera's focal length
        private float focalLength;
        // estimated transformation

        private bool isPoseEstimated = false;
        private float modelRadius;

        // size of the opened image
        private Size imageSize = new Size(0, 0);
        // colors used to highlight points on image
        private Color[] pointsColors = new Color[4]
        {
            Color.Yellow, Color.Blue, Color.Red, Color.Lime
        };

        private bool useCoplanarPosit = true;

        // point index currently locating with mouse
        private int pointIndexToLocate = -1;
        private AForge.Point pointPreviousValue;

        // model used to draw coordinate system's axes
        private Vector3[] axesModel = new Vector3[]
        {
            new Vector3( 0, 0, 0 ),
            new Vector3( 1, 0, 0 ),
            new Vector3( 0, 1, 0 ),
            new Vector3( 0, 0, 1 ),
        };
        // a structure describing built-in sample
        private struct Sample
        {

            public readonly string ImageName;
            public readonly AForge.Point[] ImagePoints;
            public readonly Vector3[] ModelPoints;
            public readonly float FocalLength;
            public readonly bool IsCoplanar;

            public Sample(string imageName, AForge.Point[] imagePoints, Vector3[] modelPoints, float focalLength, bool isCoplanar)
            {
                ImageName = imageName;
                ImagePoints = imagePoints;
                ModelPoints = modelPoints;
                FocalLength = focalLength;
                IsCoplanar = isCoplanar;
            }
        }
        #endregion
        DateTime gtime;
        Matrix3x3 rotationMatrix = new Matrix3x3();
        Matrix3x3 bestRotationMatrix = new Matrix3x3();
        Matrix3x3 alternateRotationMatrix = new Matrix3x3();
        Vector3 translationVector = new Vector3();
        Vector3 bestTranslationVector = new Vector3();
        Vector3 alternateTranslationVector = new Vector3();
        public Form1()
        {


            matrixA = new Matrix3x3()
            {
                V00 = 0.0F,
                V01 = 0.0F,
                V02 = 0.0F,
                V10 = 0.0F,
                V11 = 0.0F,
                V12 = 0.0F,
                V20 = 0.0F,
                V21 = 0.0F,
                V22 = 0.0F
            };
            matrixB = new Matrix3x3()
            {
                V00 = 0.0F,
                V01 = 0.0F,
                V02 = 0.0F,
                V10 = 0.0F,
                V11 = 0.0F,
                V12 = 0.0F,
                V20 = 0.0F,
                V21 = 0.0F,
                V22 = 0.0F
            };
            matrixC = new Matrix3x3()
            {
                V00 = 0.0F,
                V01 = 0.0F,
                V02 = 0.0F,
                V10 = 0.0F,
                V11 = 0.0F,
                V12 = 0.0F,
                V20 = 0.0F,
                V21 = 0.0F,
                V22 = 0.0F
            };
            //focalLength = 1920;
            //focalLength = 640;
            Label.CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
            glyphsImageList.ImageSize = new Size(32, 32);
            glyphList.LargeImageList = glyphsImageList;

            //poset
            //imagePoint1ColorLabel.BackColor = pointsColors[0];
            //imagePoint2ColorLabel.BackColor = pointsColors[1];
            //imagePoint3ColorLabel.BackColor = pointsColors[2];
            //imagePoint4ColorLabel.BackColor = pointsColors[3];

            //if (useCoplanarPosit)
            //{
            //    copositRadio.Checked = true;
            //}
            //else
            //{
            //    positRadio.Checked = true;
            //}

            imagePoints[0] = emptyPoint;
            imagePoints[1] = emptyPoint;
            imagePoints[2] = emptyPoint;
            imagePoints[3] = emptyPoint;
            label5.Text = "";
            label6.Text = "";
            label7.Text = "";
            //ClearEstimation();
        }
        //private void ClearEstimation()
        //{
        //    isPoseEstimated = false;
        //    estimatedTransformationMatrixControl.Clear();
        //    bestPoseButton.Visible = false;
        //    alternatePoseButton.Visible = false;
        //}
        private void button1_Click(object sender, EventArgs e)
        {
            VideoCaptureDeviceForm form = new VideoCaptureDeviceForm();
            if (form.ShowDialog(this) == DialogResult.OK)
            {
                OpenVideoSource(form.VideoDevice);
            }
        }

        private void OpenVideoSource(IVideoSource source)
        {
            this.Cursor = Cursors.WaitCursor;
            imageProcessor.Reset();

            videoSourcePlayer.SignalToStop();
            videoSourcePlayer.WaitForStop();

            videoSourcePlayer.VideoSource = new AsyncVideoSource(source);
            videoSourcePlayer.Start();
            stopWatch = null;
            timer.Start();

            this.Cursor = Cursors.Default;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // create video source
                FileVideoSource fileSource = new FileVideoSource(openFileDialog.FileName);

                // open it
                OpenVideoSource(fileSource);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            imageProcessor.VisualizationType = (VisualizationType.BorderOnly);
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            IVideoSource videoSource = videoSourcePlayer.VideoSource;
            if (videoSource != null)
            {
                int framesReceived = videoSource.FramesReceived;
                if (stopWatch == null)
                {
                    stopWatch = new Stopwatch();
                    stopWatch.Start();
                }
                else
                {
                    stopWatch.Stop();

                    float fps = 1000.0f * framesReceived / stopWatch.ElapsedMilliseconds;
                    fpsLabel.Text = fps.ToString("F2") + " fps";

                    stopWatch.Reset();
                    stopWatch.Start();
                }
            }
        }

        // On new video frame
        private void videoSourcePlayer_NewFrame(object sender, ref Bitmap image)
        {
            //image = new Bitmap(image, 640, 480);
            if (activeGlyphDatabase != null)
            {
                if (image.PixelFormat == PixelFormat.Format8bppIndexed)
                {
                    // convert image to RGB if it is grayscale
                    GrayscaleToRGB filter = new GrayscaleToRGB();

                    Bitmap temp = filter.Apply(image);
                    image.Dispose();
                    image = temp;
                }

                lock (sync)
                {
                    List<ExtractedGlyphData> glyphs = imageProcessor.ProcessImage(image);

                    if (arForm != null)
                    {
                        List<VirtualModel> modelsToDisplay = new List<VirtualModel>();

                        foreach (ExtractedGlyphData glyph in glyphs)
                        {
                            if ((glyph.RecognizedGlyph != null) &&
                                 (glyph.RecognizedGlyph.UserData != null) &&
                                 (glyph.RecognizedGlyph.UserData is GlyphVisualizationData) &&
                                 (glyph.IsTransformationDetected))
                            {
                                modelsToDisplay.Add(new VirtualModel(
                                    ((GlyphVisualizationData)glyph.RecognizedGlyph.UserData).ModelName,
                                    glyph.TransformationMatrix,
                                    imageProcessor.GlyphSize));
                            }
                        }

                        arForm.UpdateScene(image, modelsToDisplay);
                    }
                    if (glyphs.Count > 0)
                    {
                        foreach (var item in glyphs)
                        {
                            try
                            {

                                EstimatePose(item.RecognizedQuadrilateral, item.RecognizedGlyph.Name);

                            }
                            catch (Exception)
                            {

                            }
                        }
                    }
                }
            }
        }

        private void EstimatePose(List<IntPoint> Pointsinput, string Name)
        {

            try
            {
                lock (sync)
                {
                    IntPoint[] intpoints = Pointsinput.ToArray();
                    modelPoints = new Vector3[]
                    {
                    //new Vector3() { X = -56.5F,Y = 0,Z = 56.5F},
                    //new Vector3() { X = 56.5F,Y = 0,Z = 56.5F},
                    //new Vector3() { X = 56.5F,Y = 0,Z = -56.5F},
                    //new Vector3() { X = -56.5F,Y = 0,Z = -56.5F}

                    new Vector3() { X = -73.0F,Y =-73.0F  ,Z =0},
                    new Vector3() { X = 73.0F, Y =-73.0F  ,Z =0},
                    new Vector3() { X = 73.0F, Y = 73.0F  ,Z =0},
                    new Vector3() { X = -73.0F,Y = 73.0F  ,Z =0}


                    //new Vector3() { X = -48.0F,Y = -48.0F,Z = 0.0F},
                    //new Vector3() { X = 48.0F,Y =-48.0F,Z = 0.0F},
                    //new Vector3() { X = 48.0F,Y = 48.0F,Z = 0.0F},
                    //new Vector3() { X = -48.0F,Y = 48.0F,Z = 0.0F}


                    };


                    Vector3 modelCenter = new Vector3(
                   (modelPoints[0].X + modelPoints[1].X + modelPoints[2].X + modelPoints[3].X) / 4,
                   (modelPoints[0].Y + modelPoints[1].Y + modelPoints[2].Y + modelPoints[3].Y) / 4,
                   (modelPoints[0].Z + modelPoints[1].Z + modelPoints[2].Z + modelPoints[3].Z) / 4);



                    modelRadius = 0;



                    float estimatedYaw;
                    float estimatedPitch;
                    float estimatedRoll;

                    foreach (Vector3 modelPoint in modelPoints)
                    {
                        float distanceToCenter = (modelPoint - modelCenter).Norm;
                        if (distanceToCenter > modelRadius)
                        {
                            modelRadius = distanceToCenter;
                        }
                    }

                    // Vector3 temp = new Vector3() { [0.2244F,-0.5206F,0.8248F], [0.4353F,0.8111F,0.3811F], [-0.8826,0.2719,0.4055]};
                    //Matrix3x3 temp = new Matrix3x3() { V00 = 0.2244F, V01 = -0.5206F, V02 = 0.8248F, V10 = 0.4353F, V11 = 0.8111F, V12 = 0.3811F, V20 = -0.8826F, V21 = 0.2719F, V22 = 0.4055F };
                    Matrix3x3 matrix = new Matrix3x3()
                    {
                        V00 = float.Parse(tbx00.Text),
                        V01 = float.Parse(tbx01.Text),
                        V02 = float.Parse(tbx02.Text),
                        V10 = float.Parse(tbx10.Text),
                        V11 = float.Parse(tbx11.Text),
                        V12 = float.Parse(tbx12.Text),
                        V20 = float.Parse(tbx20.Text),
                        V21 = float.Parse(tbx21.Text),
                        V22 = float.Parse(tbx22.Text)
                    };

                    if (Name == "A")
                    {
                        //kfA1.Push(Convert.ToDouble(intpoints[0].X), Convert.ToDouble(intpoints[0].Y));
                        //kfA2.Push(Convert.ToDouble(intpoints[1].X), Convert.ToDouble(intpoints[1].Y));
                        //kfA3.Push(Convert.ToDouble(intpoints[2].X), Convert.ToDouble(intpoints[2].Y));
                        //kfA4.Push(Convert.ToDouble(intpoints[3].X), Convert.ToDouble(intpoints[3].Y));

                        AForge.Point[] points = new AForge.Point[]
                        {

                        new AForge.Point(){X = Convert.ToInt32(intpoints[0].X), Y = Convert.ToInt32(intpoints[0].Y) },
                        new AForge.Point(){X = Convert.ToInt32(intpoints[1].X), Y = Convert.ToInt32(intpoints[1].Y) },
                        new AForge.Point(){X = Convert.ToInt32(intpoints[2].X), Y = Convert.ToInt32(intpoints[2].Y) },
                        new AForge.Point(){X = Convert.ToInt32(intpoints[3].X), Y = Convert.ToInt32(intpoints[3].Y) }
                        };
                        if (!useCoplanarPosit)
                        {
                            Posit posit = new Posit(modelPoints, focalLength);
                            posit.EstimatePose(points, out rotationMatrix, out translationVector);

                            //bestPoseButton.Visible = alternatePoseButton.Visible = false;
                        }
                        else
                        {
                            CoplanarPosit coposit = new CoplanarPosit(modelPoints, focalLength);
                            coposit.EstimatePose(points, out rotationMatrix, out translationVector);

                            bestRotationMatrix = coposit.BestEstimatedRotation;
                            bestTranslationVector = coposit.BestEstimatedTranslation;
                            // translationVector = new Vector3() { X = bestTranslationVector.X, Y = -bestTranslationVector.Z, Z = -bestTranslationVector.Y };
                            alternateRotationMatrix = coposit.AlternateEstimatedRotation;
                            alternateTranslationVector = coposit.AlternateEstimatedTranslation;


                        }
                        // zarb
                        if (chbuseit.Checked == true)
                        {

                            rotationMatrix = matrixA * rotationMatrix;
                            if (!chbafter.Checked)
                                rotationMatrix = matrix * rotationMatrix;
                            else
                                rotationMatrix = rotationMatrix * matrix;
                        }
                        //rotationMatrix.ExtractYawPitchRoll(out estimatedYaw, out estimatedPitch, out estimatedRoll);
                        //rotationMatrix = rotationMatrix * 1;

                        rotationMatrix = rotationMatrix.Transpose();
                        //float p, r, y;
                        //rotationMatrix.MyExtractYawPitchRoll(out p, out r, out y);


                        estimatedPitch = (float)Math.Asin(-rotationMatrix.V02);
                        estimatedYaw = (float)Math.Atan2(rotationMatrix.V01, rotationMatrix.V00);
                        estimatedRoll = (float)Math.Atan2(rotationMatrix.V12, rotationMatrix.V22);
                        var a = estimatedYaw * (float)(180.0 / Math.PI);
                        yawa = estimatedYaw = Convert.ToSingle(KAYaw.Output(a));
                        var p = estimatedPitch * (float)(180.0 / Math.PI);
                        pitcha = estimatedPitch = Convert.ToSingle(KAPitch.Output(p));
                        var r = estimatedRoll * (float)(180.0 / Math.PI);
                        rolla = estimatedRoll = Convert.ToSingle(KARoll.Output(r));

                        // TO DOO
                        label1.Text = string.Format("A :: Rotation: (yaw(y)={0}, pitch(x)={1}, roll(z)={2})",
                                          Convert.ToInt32(estimatedYaw), Convert.ToInt32(estimatedPitch), Convert.ToInt32(estimatedRoll));
                        //label1.Text = string.Format("Rotation: (teta(y)={0}, fi(x)={1}, saw(z)={2})",
                        //                  Convert.ToInt32(p), Convert.ToInt32(r), Convert.ToInt32(y));
                        estimatedTransformationMatrixControl1.SetMatrix(
                                                              Matrix4x4.CreateTranslation(translationVector) *
                                                             Matrix4x4.CreateFromRotation(rotationMatrix));
                    }
                    else if (Name == "B")
                    {
                        //kfB1.Push(Convert.ToDouble(intpoints[0].X), Convert.ToDouble(intpoints[0].Y));
                        //kfB2.Push(Convert.ToDouble(intpoints[1].X), Convert.ToDouble(intpoints[1].Y));
                        //kfB3.Push(Convert.ToDouble(intpoints[2].X), Convert.ToDouble(intpoints[2].Y));
                        //kfB4.Push(Convert.ToDouble(intpoints[3].X), Convert.ToDouble(intpoints[3].Y));

                        //AForge.Point[] points = new AForge.Point[]
                        //{
                        //new AForge.Point(){X = Convert.ToInt32(kfB1.X), Y = Convert.ToInt32(kfB1.Y) },
                        //new AForge.Point(){X = Convert.ToInt32(kfB2.X), Y = Convert.ToInt32(kfB2.Y) },
                        //new AForge.Point(){X = Convert.ToInt32(kfB3.X), Y = Convert.ToInt32(kfB3.Y) },
                        //new AForge.Point(){X = Convert.ToInt32(kfB4.X), Y = Convert.ToInt32(kfB4.Y) }
                        //};
                        AForge.Point[] points = new AForge.Point[]
                        {
                        new AForge.Point(){X = intpoints[0].X, Y = intpoints[0].Y },
                        new AForge.Point(){X = intpoints[1].X, Y = intpoints[1].Y },
                        new AForge.Point(){X = intpoints[2].X, Y = intpoints[2].Y },
                        new AForge.Point(){X = intpoints[3].X, Y = intpoints[3].Y }
                       };
                        if (!useCoplanarPosit)
                        {
                            Posit posit = new Posit(modelPoints, focalLength);
                            posit.EstimatePose(points, out rotationMatrix, out translationVector);

                            //bestPoseButton.Visible = alternatePoseButton.Visible = false;
                        }
                        else
                        {
                            CoplanarPosit coposit = new CoplanarPosit(modelPoints, focalLength);
                            coposit.EstimatePose(points, out rotationMatrix, out translationVector);

                            bestRotationMatrix = coposit.BestEstimatedRotation;
                            bestTranslationVector = coposit.BestEstimatedTranslation;
                            // translationVector = new Vector3() { X = bestTranslationVector.X, Y = -bestTranslationVector.Z, Z = -bestTranslationVector.Y };
                            alternateRotationMatrix = coposit.AlternateEstimatedRotation;
                            alternateTranslationVector = coposit.AlternateEstimatedTranslation;


                        }
                        // zarb
                        if (chbuseit.Checked == true)
                        {
                            rotationMatrix = matrixB * rotationMatrix;
                            if (!chbafter.Checked)
                                rotationMatrix = matrix * rotationMatrix;
                            else
                                rotationMatrix = rotationMatrix * matrix;
                        }
                        //rotationMatrix.ExtractYawPitchRoll(out estimatedYaw, out estimatedPitch, out estimatedRoll);
                        //rotationMatrix = rotationMatrix * 1;
                        //rotationMatrix.MyExtractYawPitchRoll(out teta, out fi, out saw);
                        rotationMatrix = rotationMatrix.Transpose();

                        estimatedPitch = (float)Math.Asin(-rotationMatrix.V02);
                        estimatedYaw = (float)Math.Atan2(rotationMatrix.V01, rotationMatrix.V00);
                        estimatedRoll = (float)Math.Atan2(rotationMatrix.V12, rotationMatrix.V22);

                        yawb = estimatedYaw = Convert.ToSingle(KBYaw.Output(estimatedYaw * (float)(180.0 / Math.PI)));
                        pitchb = estimatedPitch = Convert.ToSingle(KBPitch.Output(estimatedPitch * (float)(180.0 / Math.PI)));
                        rollb = estimatedRoll = Convert.ToSingle(KBRoll.Output(estimatedRoll * (float)(180.0 / Math.PI)));
                        // TO DOO
                        label2.Text = string.Format("B  ::  Rotation: (yaw(y)={0}, pitch(x)={1}, roll(z)={2})",
                                               Convert.ToInt32(estimatedYaw), Convert.ToInt32(estimatedPitch), Convert.ToInt32(estimatedRoll));
                        //label6.Text = string.Format("Rotation: (yaw(y)={0}, pitch(x)={1}, roll(z)={2})",
                        //                       Convert.ToInt32(teta), Convert.ToInt32(fi), Convert.ToInt32(saw));
                        estimatedTransformationMatrixControl2.SetMatrix(
                           Matrix4x4.CreateTranslation(translationVector) *
                            Matrix4x4.CreateFromRotation(rotationMatrix));
                    }
                    else if (Name == "C")
                    {
                        //kfC1.Push(Convert.ToDouble(intpoints[0].X), Convert.ToDouble(intpoints[0].Y));
                        //kfC2.Push(Convert.ToDouble(intpoints[1].X), Convert.ToDouble(intpoints[1].Y));
                        //kfC3.Push(Convert.ToDouble(intpoints[2].X), Convert.ToDouble(intpoints[2].Y));
                        //kfC4.Push(Convert.ToDouble(intpoints[3].X), Convert.ToDouble(intpoints[3].Y));

                        AForge.Point[] points = new AForge.Point[]
                        {
                        new AForge.Point(){X = Convert.ToInt32(intpoints[0].X), Y = Convert.ToInt32(intpoints[0].Y) },
                        new AForge.Point(){X = Convert.ToInt32(intpoints[1].X), Y = Convert.ToInt32(intpoints[1].Y) },
                        new AForge.Point(){X = Convert.ToInt32(intpoints[2].X), Y = Convert.ToInt32(intpoints[2].Y) },
                        new AForge.Point(){X = Convert.ToInt32(intpoints[3].X), Y = Convert.ToInt32(intpoints[3].Y) }
                        };
                        if (!useCoplanarPosit)
                        {
                            Posit posit = new Posit(modelPoints, focalLength);
                            posit.EstimatePose(points, out rotationMatrix, out translationVector);

                            //bestPoseButton.Visible = alternatePoseButton.Visible = false;
                        }
                        else
                        {
                            CoplanarPosit coposit = new CoplanarPosit(modelPoints, focalLength);
                            coposit.EstimatePose(points, out rotationMatrix, out translationVector);

                            bestRotationMatrix = coposit.BestEstimatedRotation;
                            bestTranslationVector = coposit.BestEstimatedTranslation;
                            // translationVector = new Vector3() { X = bestTranslationVector.X, Y = -bestTranslationVector.Z, Z = -bestTranslationVector.Y };
                            alternateRotationMatrix = coposit.AlternateEstimatedRotation;
                            alternateTranslationVector = coposit.AlternateEstimatedTranslation;


                        }
                        // zarb
                        if (chbuseit.Checked == true)
                        {

                            rotationMatrix = matrixC * rotationMatrix;
                            if (!chbafter.Checked)
                                rotationMatrix = matrix * rotationMatrix;
                            else
                                rotationMatrix = rotationMatrix * matrix;
                        }
                        //rotationMatrix.ExtractYawPitchRoll(out estimatedYaw, out estimatedPitch, out estimatedRoll);
                        //rotationMatrix = rotationMatrix * 1;
                        //rotationMatrix.MyExtractYawPitchRoll(out teta, out fi, out saw);
                        rotationMatrix = rotationMatrix.Transpose();


                        estimatedPitch = (float)Math.Asin(-rotationMatrix.V02);
                        estimatedYaw = (float)Math.Atan2(rotationMatrix.V01, rotationMatrix.V00);
                        estimatedRoll = (float)Math.Atan2(rotationMatrix.V12, rotationMatrix.V22);

                        yawc = estimatedYaw = Convert.ToSingle(KCYaw.Output(estimatedYaw * (float)(180.0 / Math.PI)));
                        pitchc = estimatedPitch = Convert.ToSingle(KCPitch.Output(estimatedPitch * (float)(180.0 / Math.PI)));
                        rollc = estimatedRoll = Convert.ToSingle(KCRoll.Output(estimatedRoll * (float)(180.0 / Math.PI)));
                        // TO DOO

                        label8.Text = string.Format("C  ::  Rotation: (yaw(y)={0}, pitch(x)={1}, roll(z)={2})",
                                                                    Convert.ToInt32(estimatedYaw), Convert.ToInt32(estimatedPitch), Convert.ToInt32(estimatedRoll));
                        //label7.Text = string.Format("Rotation: (yaw(y)={0}, pitch(x)={1}, roll(z)={2})",
                        //                       Convert.ToInt32(teta), Convert.ToInt32(fi), Convert.ToInt32(saw));
                        estimatedTransformationMatrixControl3.SetMatrix(
                              Matrix4x4.CreateTranslation(translationVector) *
                               Matrix4x4.CreateFromRotation(rotationMatrix));
                    }
                    //bestPoseButton.Visible = alternatePoseButton.Visible = true;

                }
            }
            catch (Exception ex)
            {


            }
        }

        private void videoSourcePlayer_PlayingFinished(object sender, ReasonToFinishPlaying reason)
        {

        }

        /// <summary>
        /// Append a graph.
        /// </summary>
        /// <param name="c"></param>
        /// <param name="name"></param>
        /// <param name="vals"></param>
        /// <param name="clr"></param>
        protected void graph(Chart c, string name, List<double> valList, Color clr)
        {

            Series s = new Series(name);
            s.ChartType = SeriesChartType.Line;
            var vals = valList.ToArray();
            for (int i = 0; i < vals.Length; i++)
            {
                s.Points.Add(new DataPoint(i, vals[i]));
            }
            s.Color = clr;
            c.Series.Add(s);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            aListRoll = new List<double>() { 0};
            aListPitch = new List<double>() { 0 };
            aListYaw = new List<double>() { 0 };

            bListRoll = new List<double>() { 0 };
            bListPitch = new List<double>() { 0 };
            bListYaw = new List<double>() { 0 };

            cListRoll = new List<double>() { 0 };
            cListPitch = new List<double>() { 0 };
            cListYaw = new List<double>() { 0 };

            double A = 1;
            double H = 1;
            double Q = 0.900;//noise
            double R = 100;
            double P = 0.1;
            double x = 0;
            KARoll = new KalmanFilter(A, H, Q, R, P, x);
            KAPitch = new KalmanFilter(A, H, Q, R, P, x);
            KAYaw = new KalmanFilter(A, H, Q, R, P, x);

            KBRoll = new KalmanFilter(A, H, Q, R, P, x);
            KBPitch = new KalmanFilter(A, H, Q, R, P, x);
            KBYaw = new KalmanFilter(A, H, Q, R, P, x);

            KCRoll = new KalmanFilter(A, H, Q, R, P, x);
            KCPitch = new KalmanFilter(A, H, Q, R, P, x);
            KCYaw = new KalmanFilter(A, H, Q, R, P, x);
            //(1, 1, 0.250, 1, 0.1, 0);

            //kfA1.NoiseX = double.Parse(klmNoiseX.Text);
            //kfA1.NoiseY = double.Parse(klmNoiseY.Text);
            //kfA2.NoiseX = double.Parse(klmNoiseX.Text);
            //kfA2.NoiseY = double.Parse(klmNoiseY.Text);
            //kfA3.NoiseX = double.Parse(klmNoiseX.Text);
            //kfA3.NoiseY = double.Parse(klmNoiseY.Text);
            //kfA4.NoiseX = double.Parse(klmNoiseX.Text);
            //kfA4.NoiseY = double.Parse(klmNoiseY.Text);


            //kfB1.NoiseX = double.Parse(klmNoiseX.Text);
            //kfB1.NoiseY = double.Parse(klmNoiseY.Text);
            //kfB2.NoiseX = double.Parse(klmNoiseX.Text);
            //kfB2.NoiseY = double.Parse(klmNoiseY.Text);
            //kfB3.NoiseX = double.Parse(klmNoiseX.Text);
            //kfB3.NoiseY = double.Parse(klmNoiseY.Text);
            //kfB4.NoiseX = double.Parse(klmNoiseX.Text);
            //kfB4.NoiseY = double.Parse(klmNoiseY.Text);



            //kfC1.NoiseX = double.Parse(klmNoiseX.Text);
            //kfC1.NoiseY = double.Parse(klmNoiseY.Text);
            //kfC2.NoiseX = double.Parse(klmNoiseX.Text);
            //kfC2.NoiseY = double.Parse(klmNoiseY.Text);
            //kfC3.NoiseX = double.Parse(klmNoiseX.Text);
            //kfC3.NoiseY = double.Parse(klmNoiseY.Text);
            //kfC4.NoiseX = double.Parse(klmNoiseX.Text);
            //kfC4.NoiseY = double.Parse(klmNoiseY.Text);

            estimatedTransformationMatrixControl1.Clear();
            estimatedTransformationMatrixControl2.Clear();
            estimatedTransformationMatrixControl3.Clear();
            // load configuratio
            Configuration config = Configuration.Instance;

            try
            {
                focalLength = int.Parse(textBox1.Text);
            }
            catch (Exception)
            {

            }
            if (config.Load(glyphDatabases))
            {
                RefreshListOfGlyphDatabases();
                ActivateGlyphDatabase(config.GetConfigurationOption(activeDatabaseOption));

                try
                {
                    Location = new System.Drawing.Point(
                        int.Parse(config.GetConfigurationOption(mainFormXOption)),
                        int.Parse(config.GetConfigurationOption(mainFormYOption)));

                    Size = new Size(
                        int.Parse(config.GetConfigurationOption(mainFormWidthOption)),
                        int.Parse(config.GetConfigurationOption(mainFormHeightOption)));

                    WindowState = (FormWindowState)Enum.Parse(typeof(FormWindowState),
                        config.GetConfigurationOption(mainFormStateOption));

                    splitContainer.SplitterDistance = int.Parse(config.GetConfigurationOption(mainSplitterOption));

                    autoDetectFocalLength = bool.Parse(config.GetConfigurationOption(autoDetectFocalLengthOption));
                    imageProcessor.GlyphSize = float.Parse(config.GetConfigurationOption(glyphSizeOption));
                    if (!autoDetectFocalLength)
                    {
                        imageProcessor.CameraFocalLength = float.Parse(config.GetConfigurationOption(focalLengthOption));
                    }
                }
                catch
                {
                }
            }
        }

        private void glyphCollectionsList_AfterLabelEdit(object sender, LabelEditEventArgs e)
        {
            if (e.Label != null)
            {
                string newName = e.Label.Trim();

                if (newName == string.Empty)
                {
                    ShowErrorBox("Collection name cannot be emtpy.");
                    e.CancelEdit = true;
                    return;
                }
                else
                {
                    string oldName = glyphCollectionsList.Items[e.Item].Text;

                    if (oldName != newName)
                    {
                        if (glyphDatabases.GetDatabaseNames().Contains(newName))
                        {
                            ShowErrorBox("A collection with such name already exists.");
                            e.CancelEdit = true;
                            return;
                        }

                        glyphDatabases.RenameGlyphDatabase(oldName, newName);

                        // update name of active database if it was renamed
                        if (activeGlyphDatabaseName == oldName)
                            activeGlyphDatabaseName = newName;

                        if (newName != e.Label)
                        {
                            glyphCollectionsList.Items[e.Item].Text = newName;
                            e.CancelEdit = true;
                        }
                    }
                    else
                    {
                        e.CancelEdit = true;
                    }
                }
            }
        }
        private void ShowErrorBox(string message)
        {
            MessageBox.Show(message, ErrorBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void activateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (glyphCollectionsList.SelectedIndices.Count == 1)
            {
                ActivateGlyphDatabase(glyphCollectionsList.SelectedItems[0].Text);
            }
        }
        private void ActivateGlyphDatabase(string name)
        {
            ListViewItem lvi;

            // deactivate previous database
            if (activeGlyphDatabase != null)
            {
                lvi = GetListViewItemByName(glyphCollectionsList, activeGlyphDatabaseName);

                if (lvi != null)
                {
                    Font font = new Font(lvi.Font, FontStyle.Regular);
                    lvi.Font = font;
                }
            }

            // activate new database
            activeGlyphDatabaseName = name;

            if (name != null)
            {
                try
                {
                    activeGlyphDatabase = glyphDatabases[name];

                    lvi = GetListViewItemByName(glyphCollectionsList, name);

                    if (lvi != null)
                    {
                        Font font = new Font(lvi.Font, FontStyle.Bold);
                        lvi.Font = font;
                    }
                }
                catch
                {
                }
            }
            else
            {
                activeGlyphDatabase = null;
            }

            // set the database to image processor ...
            imageProcessor.GlyphDatabase = activeGlyphDatabase;
            // ... and show it to user
            RefreshListOfGlyps();
        }
        private ListViewItem GetListViewItemByName(ListView lv, string name)
        {
            try
            {
                return lv.Items[name];
            }
            catch
            {
                return null;
            }
        }
        private void RefreshListOfGlyps()
        {
            // clear list view and its image list
            glyphList.Items.Clear();
            glyphsImageList.Images.Clear();

            if (activeGlyphDatabase != null)
            {
                // update image list first
                foreach (Glyph glyph in activeGlyphDatabase)
                {
                    // create icon for the glyph first
                    glyphsImageList.Images.Add(glyph.Name, CreateGlyphIcon(glyph));

                    // create glyph's list view item
                    ListViewItem lvi = glyphList.Items.Add(glyph.Name);
                    lvi.ImageKey = glyph.Name;
                }
            }
        }
        private Bitmap CreateGlyphIcon(Glyph glyph)
        {
            return CreateGlyphImage(glyph, 32);
        }

        private Bitmap CreateGlyphImage(Glyph glyph, int width)
        {
            Bitmap bitmap = new Bitmap(width, width, System.Drawing.Imaging.PixelFormat.Format32bppArgb);

            int cellSize = width / glyph.Size;
            int glyphSize = glyph.Size;

            for (int i = 0; i < width; i++)
            {
                int yCell = i / cellSize;

                for (int j = 0; j < width; j++)
                {
                    int xCell = j / cellSize;

                    if ((yCell >= glyphSize) || (xCell >= glyphSize))
                    {
                        // set pixel to transparent if it outside of the glyph
                        bitmap.SetPixel(j, i, Color.Transparent);
                    }
                    else
                    {
                        // set pixel to black or white depending on glyph value
                        bitmap.SetPixel(j, i,
                            (glyph.Data[yCell, xCell] == 0) ? Color.Black : Color.White);
                    }
                }
            }

            return bitmap;
        }
        private void RefreshListOfGlyphDatabases()
        {
            glyphCollectionsList.Items.Clear();

            List<string> dbNames = glyphDatabases.GetDatabaseNames();

            foreach (string name in dbNames)
            {
                GlyphDatabase db = glyphDatabases[name];
                ListViewItem lvi = glyphCollectionsList.Items.Add(name);
                lvi.Name = name;

                lvi.SubItems.Add(string.Format("{0}x{1}", db.Size, db.Size));
            }
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewGlyphCollectionForm newCollectionForm = new NewGlyphCollectionForm(glyphDatabases.GetDatabaseNames());

            if (newCollectionForm.ShowDialog() == DialogResult.OK)
            {
                string name = newCollectionForm.CollectionName;
                int size = newCollectionForm.GlyphSize;

                GlyphDatabase db = new GlyphDatabase(size);

                try
                {
                    glyphDatabases.AddGlyphDatabase(name, db);

                    // add new item to list view
                    ListViewItem lvi = glyphCollectionsList.Items.Add(name);
                    lvi.SubItems.Add(string.Format("{0}x{1}", size, size));
                    lvi.Name = name;
                }
                catch
                {
                    ShowErrorBox(string.Format("A glyph database with the name '{0}' already exists.", name));
                }
            }
        }

        private void renameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (glyphCollectionsList.SelectedIndices.Count == 1)
            {
                glyphCollectionsList.Items[glyphCollectionsList.SelectedIndices[0]].BeginEdit();
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (glyphCollectionsList.SelectedIndices.Count == 1)
            {
                string selecteItem = glyphCollectionsList.SelectedItems[0].Text;

                if (selecteItem == activeGlyphDatabaseName)
                {
                    ActivateGlyphDatabase(null);
                }

                glyphDatabases.RemoveGlyphDatabase(selecteItem);
                glyphCollectionsList.Items.Remove(glyphCollectionsList.SelectedItems[0]);
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (fs != null)
                fs.Close();
            Configuration config = Configuration.Instance;

            if (WindowState != FormWindowState.Minimized)
            {
                if (WindowState != FormWindowState.Maximized)
                {
                    config.SetConfigurationOption(mainFormXOption, Location.X.ToString());
                    config.SetConfigurationOption(mainFormYOption, Location.Y.ToString());
                    config.SetConfigurationOption(mainFormWidthOption, Width.ToString());
                    config.SetConfigurationOption(mainFormHeightOption, Height.ToString());
                }
                config.SetConfigurationOption(mainFormStateOption, WindowState.ToString());
                config.SetConfigurationOption(mainSplitterOption, splitContainer.SplitterDistance.ToString());
            }

            config.SetConfigurationOption(activeDatabaseOption, activeGlyphDatabaseName);

            config.SetConfigurationOption(autoDetectFocalLengthOption, autoDetectFocalLength.ToString());
            config.SetConfigurationOption(focalLengthOption, imageProcessor.CameraFocalLength.ToString());
            config.SetConfigurationOption(glyphSizeOption, imageProcessor.GlyphSize.ToString());

            try
            {
                config.Save(glyphDatabases);
            }
            catch (IOException ex)
            {
                ShowErrorBox("Failed saving confguration file.\r\n\r\n" + ex.Message);
            }

            if (videoSourcePlayer.VideoSource != null)
            {
                videoSourcePlayer.SignalToStop();
                videoSourcePlayer.WaitForStop();
            }
        }
        string glyphNameInEditor = string.Empty;

        private void button5_Click(object sender, EventArgs e)
        {
            gtime = DateTime.Now;
            if (!Write)
            {
                Write = true;
                button5.Enabled = false;
                string time = System.DateTime.Now.ToString("yyyy-MM-dd hh-mm-ss-ff");
                fs = File.Create(time + ".txt");
                byte[] title = new UTF8Encoding(true).GetBytes("Time                  A:yaw,pitch,roll    B:yaw,pitch,roll    C:yaw,pitch,roll\r\n");
                fs.Write(title, 0, title.Length);
                timer1.Start();
                button5.Enabled = true;
                button5.Text = "Stop";
            }
            else
            {
                timer1.Stop();
                Write = false;
                button5.Enabled = false;
                fs.Close();
                button5.Enabled = true;
                button5.Text = "Start To Write";
            }
        }

        private void klmNoiseX_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //kfA1.NoiseX = double.Parse(klmNoiseX.Text);
                //kfA2.NoiseX = double.Parse(klmNoiseX.Text);
                //kfA3.NoiseX = double.Parse(klmNoiseX.Text);
                //kfA4.NoiseX = double.Parse(klmNoiseX.Text);


                //kfB1.NoiseX = double.Parse(klmNoiseX.Text);
                //kfB2.NoiseX = double.Parse(klmNoiseX.Text);
                //kfB3.NoiseX = double.Parse(klmNoiseX.Text);
                //kfB4.NoiseX = double.Parse(klmNoiseX.Text);


                //kfC1.NoiseX = double.Parse(klmNoiseX.Text);
                //kfC2.NoiseX = double.Parse(klmNoiseX.Text);
                //kfC3.NoiseX = double.Parse(klmNoiseX.Text);
                //kfC4.NoiseX = double.Parse(klmNoiseX.Text);
            }
            catch (Exception)
            {


            }
        }

        private void klmNoiseY_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //kfA1.NoiseY = double.Parse(klmNoiseY.Text);
                //kfA2.NoiseY = double.Parse(klmNoiseY.Text);
                //kfA3.NoiseY = double.Parse(klmNoiseY.Text);
                //kfA4.NoiseY = double.Parse(klmNoiseY.Text);


                //kfB1.NoiseY = double.Parse(klmNoiseY.Text);
                //kfB2.NoiseY = double.Parse(klmNoiseY.Text);
                //kfB3.NoiseY = double.Parse(klmNoiseY.Text);
                //kfB4.NoiseY = double.Parse(klmNoiseY.Text);



                //kfC1.NoiseY = double.Parse(klmNoiseY.Text);
                //kfC2.NoiseY = double.Parse(klmNoiseY.Text);
                //kfC3.NoiseY = double.Parse(klmNoiseY.Text);
                //kfC4.NoiseY = double.Parse(klmNoiseY.Text);
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int h = DateTime.Now.Hour - gtime.Hour;
            int m = DateTime.Now.Minute - gtime.Minute;
            int s = DateTime.Now.Second - gtime.Second;
            int ms = DateTime.Now.Millisecond - gtime.Millisecond;
            float time = h * 3600 + m * 60 + s + ms / 1000.0F;

            if (rolla != 500) aListRoll.Add(rolla); else aListRoll.Add(aListRoll.Last());
            if (pitcha != 500) aListPitch.Add(pitcha); else aListPitch.Add(aListPitch.Last());
            if (yawa != 500) aListYaw.Add(yawa); else aListYaw.Add(aListYaw.Last());

            if (rollb != 500) bListRoll.Add(rollb); else bListRoll.Add(bListRoll.Last());
            if (pitchb != 500) bListPitch.Add(pitchb); else bListPitch.Add(bListPitch.Last());
            if (yawb != 500) bListYaw.Add(yawb); else bListYaw.Add(bListYaw.Last());

            if (rollc != 500) cListRoll.Add(rollc); else cListRoll.Add(cListRoll.Last());
            if (pitchc != 500) cListPitch.Add(pitchc); else cListPitch.Add(cListPitch.Last());
            if (yawc != 500) cListYaw.Add(yawc); else cListYaw.Add(cListYaw.Last());


            rollChart.Series.Clear();
            graph(rollChart, "A Roll", aListRoll, Color.Black);
            graph(rollChart, "B Roll", bListRoll, Color.Blue);
            graph(rollChart, "C Roll", cListRoll, Color.Red);
            rollChart.ChartAreas[0].RecalculateAxesScale();

            pitchChart.Series.Clear();
            graph(pitchChart, "A Pich", aListPitch, Color.Black);
            graph(pitchChart, "B Pich", bListPitch, Color.Blue);
            graph(pitchChart, "C Pich", cListPitch, Color.Red);
            pitchChart.ChartAreas[0].RecalculateAxesScale();

            yawChart.Series.Clear();
            graph(yawChart, "A Yaw", aListYaw, Color.Black);
            graph(yawChart, "B Yaw", bListYaw, Color.Blue);
            graph(yawChart, "C Yaw", cListYaw, Color.Red);
            yawChart.ChartAreas[0].RecalculateAxesScale();

            byte[] title = new UTF8Encoding(true).GetBytes(string.Format("{0}    {1},{2},{3}    {4},{5},{6}    {7},{8},{9}\r\n", time, yawa, pitcha, rolla, yawb, pitchb, rollb, yawc, pitchc, rollc));
            fs.Write(title, 0, title.Length);
            yawa = 500; pitcha = 500; rolla = 500;
            yawb = 500; pitchb = 500; rollb = 500;
            yawc = 500; pitchc = 500; rollc = 500;
        }

        private bool CheckGlyphData(byte[,] glyphData)
        {
            if (activeGlyphDatabase != null)
            {
                int rotation;
                Glyph recognizedGlyph = activeGlyphDatabase.RecognizeGlyph(glyphData, out rotation);

                if ((recognizedGlyph != null) && (recognizedGlyph.Name != glyphNameInEditor))
                {
                    ShowErrorBox("The database already contains a glyph which looks the same as it is or after rotation.");
                    return false;
                }
            }

            return true;
        }
        private void newGlyphToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (activeGlyphDatabase != null)
            {
                // create new glyph ...
                Glyph glyph = new Glyph(string.Empty, activeGlyphDatabase.Size);
                glyphNameInEditor = string.Empty;
                // ... and pass it the glyph editting form
                EditGlyphForm glyphForm = new EditGlyphForm(glyph, activeGlyphDatabase.GetGlyphNames());
                glyphForm.Text = "New Glyph";

                // set glyph data checking handler
                glyphForm.SetGlyphDataCheckingHandeler(new GlyphDataCheckingHandeler(CheckGlyphData));

                if (glyphForm.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        lock (sync)
                        {
                            // add glyph to active database
                            activeGlyphDatabase.Add(glyph);
                        }

                        // create an icon for it
                        glyphsImageList.Images.Add(glyph.Name, CreateGlyphIcon(glyph));

                        // add it to list view
                        ListViewItem lvi = glyphList.Items.Add(glyph.Name);
                        lvi.ImageKey = glyph.Name;
                    }
                    catch
                    {
                        ShowErrorBox(string.Format("A glyph with the name '{0}' already exists in the database.", glyph.Name));
                    }
                }
            }
        }

        private void editGlyphToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditSelectedGlyph();
        }

        private void focalLen_Click(object sender, EventArgs e)
        {
            focalLength = float.Parse(textBox1.Text);
        }

        private void EditSelectedGlyph()
        {
            if ((activeGlyphDatabase != null) && (glyphList.SelectedIndices.Count != 0))
            {
                // get selected item and it glyph ...
                ListViewItem lvi = glyphList.SelectedItems[0];
                Glyph glyph = (Glyph)activeGlyphDatabase[lvi.Text].Clone();
                glyphNameInEditor = glyph.Name;
                // ... and pass it to the glyph editting form
                EditGlyphForm glyphForm = new EditGlyphForm(glyph, activeGlyphDatabase.GetGlyphNames());
                glyphForm.Text = "Edit Glyph";

                // set glyph data checking handler
                glyphForm.SetGlyphDataCheckingHandeler(new GlyphDataCheckingHandeler(CheckGlyphData));

                if (glyphForm.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        // replace glyph in the database
                        lock (sync)
                        {
                            activeGlyphDatabase.Replace(glyphNameInEditor, glyph);
                        }

                        lvi.Text = glyph.Name;

                        // temporary remove icon from the list item
                        lvi.ImageKey = null;

                        // remove old icon and add new one
                        glyphsImageList.Images.RemoveByKey(glyphNameInEditor);
                        glyphsImageList.Images.Add(glyph.Name, CreateGlyphIcon(glyph));

                        // restore item's icon
                        lvi.ImageKey = glyph.Name;
                    }
                    catch
                    {
                        ShowErrorBox(string.Format("A glyph with the name '{0}' already exists in the database.", glyph.Name));
                    }
                }
            }
        }



        private void deleteGlyphToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if ((activeGlyphDatabase != null) && (glyphList.SelectedIndices.Count != 0))
            {
                // get selected item
                ListViewItem lvi = glyphList.SelectedItems[0];

                // remove glyph from database, from list view and image list
                lock (sync)
                {
                    activeGlyphDatabase.Remove(lvi.Text);
                }
                glyphList.Items.Remove(lvi);
                glyphsImageList.Images.RemoveByKey(lvi.Text);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            PARchk.Checked = true;
        }

        private void Copy_Click(object sender, EventArgs e)
        {

            try
            {
                var mtrx1 = estimatedTransformationMatrixControl1.GetMatricx();
                matrixA = new Matrix3x3()
                {

                    // V00 = mtrx1.V00,
                    //V01 = mtrx1.V10,
                    // V02 = mtrx1.V20,
                    //V10 = mtrx1.V01,
                    // V11 = mtrx1.V11,
                    // V12 = mtrx1.V21,
                    // V20 = mtrx1.V02,
                    // V21 = mtrx1.V12,
                    //V22 = mtrx1.V22


                    V00 = mtrx1.V00,
                    V01 = mtrx1.V01,
                    V02 = mtrx1.V02,
                    V10 = mtrx1.V10,
                    V11 = mtrx1.V11,
                    V12 = mtrx1.V12,
                    V20 = mtrx1.V20,
                    V21 = mtrx1.V21,
                    V22 = mtrx1.V22
                };
            }
            catch (Exception)
            {

                matrixA = new Matrix3x3()
                {
                    V00 = 0,
                    V01 = 0,
                    V02 = 0,
                    V10 = 0,
                    V11 = 0,
                    V12 = 0,
                    V20 = 0,
                    V21 = 0,
                    V22 = 0
                };
            }
            try
            {
                var mtrx2 = estimatedTransformationMatrixControl2.GetMatricx();
                matrixB = new Matrix3x3()
                {
                    // V00 = mtrx2.V00,
                    // V01 = mtrx2.V10,
                    // V02 = mtrx2.V20,
                    // V10 = mtrx2.V01,
                    //V11 = mtrx2.V11,
                    // V12 = mtrx2.V21,
                    // V20 = mtrx2.V02,
                    //  V21 = mtrx2.V12,
                    // V22 = mtrx2.V22


                    V00 = mtrx2.V00,
                    V01 = mtrx2.V01,
                    V02 = mtrx2.V02,
                    V10 = mtrx2.V10,
                    V11 = mtrx2.V11,
                    V12 = mtrx2.V12,
                    V20 = mtrx2.V20,
                    V21 = mtrx2.V21,
                    V22 = mtrx2.V22
                };
            }
            catch (Exception)
            {
                matrixB = new Matrix3x3()
                {
                    V00 = 0,
                    V01 = 0,
                    V02 = 0,
                    V10 = 0,
                    V11 = 0,
                    V12 = 0,
                    V20 = 0,
                    V21 = 0,
                    V22 = 0
                };
            }
            try
            {
                var mtrx3 = estimatedTransformationMatrixControl3.GetMatricx();
                matrixC = new Matrix3x3()
                {
                    V00 = mtrx3.V00,
                    V01 = mtrx3.V01,
                    V02 = mtrx3.V02,
                    V10 = mtrx3.V10,
                    V11 = mtrx3.V11,
                    V12 = mtrx3.V12,
                    V20 = mtrx3.V20,
                    V21 = mtrx3.V21,
                    V22 = mtrx3.V22

                };
            }
            catch (Exception)
            {
                matrixC = new Matrix3x3()
                {
                    V00 = 0,
                    V01 = 0,
                    V02 = 0,
                    V10 = 0,
                    V11 = 0,
                    V12 = 0,
                    V20 = 0,
                    V21 = 0,
                    V22 = 0
                };
            }
        }
    }
}
