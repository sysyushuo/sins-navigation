﻿using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;

namespace Common_Namespace
{
    class WorkClasses
    {
    }

    [Serializable()]
    public class DataWithIsReady
    {
        public double Value;
        public int isReady;
    }

    [Serializable()]
    public class gps_data
    {
        public DataWithIsReady gps_Latitude = new DataWithIsReady()
                             , gps_Longitude = new DataWithIsReady()
                             , gps_Altitude = new DataWithIsReady();

        public DataWithIsReady gps_Latitude_prev = new DataWithIsReady()
                             , gps_Longitude_prev = new DataWithIsReady()
                             , gps_Altitude_prev = new DataWithIsReady();

        public DataWithIsReady gps_Ve = new DataWithIsReady()
                             , gps_Vn = new DataWithIsReady()
                             , gps_Vup = new DataWithIsReady();
    }

    [Serializable()]
    public class odometer_data
    {
        public DataWithIsReady odometer_left = new DataWithIsReady()
                             , odometer_right = new DataWithIsReady();

        public DataWithIsReady odometer_left_prev = new DataWithIsReady()
                             , odometer_right_prev = new DataWithIsReady();
    }

    [Serializable()]
    public class start_data
    {
        public DataWithIsReady start_Latitude = new DataWithIsReady(), start_Longitude = new DataWithIsReady(), start_Altitude = new DataWithIsReady();
    }




    [Serializable()]
    public class SINS_State
    {
        public string StartErrorString;
        public string Global_file = "";

        public int FreqOutput, LastCountForRead;
        public bool DoHaveControlPoints = false;

        public int NumberOfControlPoints = 0;
        public int[] ControlPointCount = new int[50];

        //---размерность вектора ошибок---
        public bool flag_iMx_r3_dV3 = false, flag_iMx_kappa_13_ds = false, flag_Odometr_SINS_case = false;
        public int iMx_r3_dV3 = 0, iMx_r12_odo = 0, iMx_odo_model = 0;

        //---мод запуска программы---
        public bool flag_Alignment = false, flag_Autonomous_Solution = false, flag_FeedbackExist = false, flag_EstimateExist = false;
        public bool flag_UsingClasAlignment = false, flag_UsingNavAlignment = false, flag_OnlyAlignment = false;
        public bool flag_OdoSINSWeakConnect = false, flag_OdoSINSWeakConnect_MODIF = false;

        //---параметры запуска---
        public bool flag_Using_iMx_r_odo_3 = false, flag_UsingAvegering = false, flag_Smoothing = false, flag_BackRun = false, flag_using_slippage = false;
        public bool flag_UseAlgebraDrift = false;

        //---параметры коррекции---
        public bool flag_UsingCorrection = false, flag_UsingAngleCorrection = false, flag_ZUPT = false, flag_UsingAltitudeCorrection = false;
        public bool flag_Using_SNS = false, flag_UseOnlyStops = false, flag_NotUse_ZUPT = false, flag_using_Checkpotints = false, flag_using_GoCalibrInCP = false;
        public bool flag_UseOdoVelocity_In_Oz = false;

        public bool flag_UsingOdoPosition = false, flag_UsingOdoVelocity = false, add_velocity_to_position = false, flag_onlyZeroSideVelocity = false;
        public bool flag_OdoModelOnlyCP = false;

        //---остальное вспомогательное---
        public bool flag_UseLastMinusOneOdo = false, flag_slipping = false;



        public string[] Strings_Input_File = new string[500000];



        //---Считывание данных из файла---
        public double FLG_Stop;
        public double Count, initCount, timeStep, Time, Time_prev;
        public gps_data GPS_Data = new gps_data();
        public odometer_data OdometerData = new odometer_data();

        public double F_z2_localAvg;
        public double[] F_z = new double[3]
                      , F_x = new double[3]
                      , F_z_prev = new double[3]
                      , W_z = new double[3]
                      , W_x = new double[3]
                      , W_z_prev = new double[3]
                      ;

        public double[] g_x = new double[3]
                      , u_s = new double[3]
                      , u_x = new double[3]
                      , Omega_x = new double[3]
                      ;

        //---матрицы ориентации---
        public Matrix AT = new Matrix(3, 3)
                    , AT_prev = new Matrix(3, 3)
                    , A_sx0 = new Matrix(3, 3)
                    , A_sx0_prev = new Matrix(3, 3)
                    , A_x0s = new Matrix(3, 3)
                    , A_x0s_prev = new Matrix(3, 3)
                    , A_x0n = new Matrix(3, 3)
                    , A_x0n_prev = new Matrix(3, 3)
                    , A_nx0 = new Matrix(3, 3)
                    , A_nx0_prev = new Matrix(3, 3)
                    , A_nxi = new Matrix(3, 3)
                    , A_nxi_prev = new Matrix(3, 3)
                      ;

        public Matrix A_sx_Gyro = new Matrix(3, 3)
                    , A_xs_Gyro = new Matrix(3, 3)
                    , A_nx_Gyro = new Matrix(3, 3)
                    , A_xn_Gyro = new Matrix(3, 3)
                    , A_sc = new Matrix(3, 3)
                    , A_cs = new Matrix(3, 3)
                    , A_x0c = new Matrix(3, 3)
                    , A_cx0 = new Matrix(3, 3)
                      ;

        //------
        public double Freq, odo_min_increment, V_abs, DistanceModeled = 0.0, Time_Alignment = 0, V_norm;

        //---Вычисляемые переменные---
        public bool init_bins = false, firstLineRead = false;
        public double[] AlignAlgebraDrifts = new double[3];
        public double GyroHeading, Heading, Roll, Pitch, PitchAuto, Heading_prev, Roll_prev, Pitch_prev, Azimth, LongSNS, LatSNS, AltSNS, g, g_0, F_mod, R_e, R_n, HeadingImitator;
        public double CourseHeading, CoursePitch, beta_c, gamma_c, alpha_c;
        public double Latitude, Longitude, Altitude, Latitude_Start, Longitude_Start, Altitude_Start, Latitude_Point, Altitude_prev, Latitude_prev, Longitude_prev;
        public double Latitude_Corr, Longitude_Corr, Altitude_Corr;

        public double[] Vx_0 = new double[3]
                      , Vx_0_prev = new double[3]
                      , Vz = new double[3]
                      , Vz_prev = new double[3]
                      , Vx = new double[3]
                      , Vx_prev = new double[3]
                      , Vc = new double[3]
                      ;

        //---Начальные  сигма для матриц S---
        public double[] stdF = new double[3];
        public double stdR, stdOdoR, stdV, stdAlpha1, stdAlpha2, stdBeta3, stdNu, stdNu_Oz1, stdScale, stdKappa1, stdKappa3;

        //---Ошибки вектора состояния системы---
        public double DeltaLatitude, DeltaLongitude, DeltaV_1, DeltaV_2, DeltaV_3, DeltaHeading, DeltaRoll, DeltaPitch, DeltaAltitude;

        //---Одометрические переменные---
        public double OdoTimeStepCount;
        public double[] OdometerVector = new double[3], OdoSpeed_x0 = new double[3], OdoSpeed_s = new double[3];
        public double OdometerLeftPrev, OdometerRightPrev, OdoAbsSpeed;
        public int OdoLimitMeasuresNum, OdoLimitMeasuresNum_Count;

        public int InertialOdometer_Count;
        public double InertialOdometer, InertialOdometer_Increment, InertialOdometer_V, InertialOdometer_temp, InertialOdometer_tempDelta;

        //---Комулятивные величины---
        public double[] Cumulative_KappaEst = new double[3];
        public double[] Cumulative_KalmanErrorVector = new double[SimpleData.iMx], Cumulative_StateErrorVector = new double[9];


        public double[] tempVect = new double[3];
        public double[] GK_Latitude = new double[50];
        public double[] GK_Longitude = new double[50];
        public double alpha_z, alpha_x, alpha_y, DirectionalAngle;

        public bool flag_iMqDeltaR = false, flag_iMqDeltaF = false, flag_iMqDeltaNu = false, flag_iMqVarkappa13 = false, flag_iMqKappa = false, flag_iMqDeltaRodo = false;
        public bool flag_AccuracyClass_NoErr;
        public bool flag_AccuracyClass_0_02grph, flag_AccuracyClass_2_0_grph, flag_AccuracyClass_0_2_grph, flag_AccuracyClass_Custom, flag_AccuracyClass_Rebuild;

        public double odotime_cur, odotime_prev;
        public bool flag_ControlPointCorrection;
        public double NumberOfFilesForSmoothing;
        public bool Saratov_run_Final;
        public bool NowSmoothing;
        public bool flag_Imitator_Telemetric;
        public int GPS_CounterOfPoints = 0;

        public bool flag_true_Marker = false;
        public int MarkersInputCount = 0, MarkerNumberLastUsed = 0;
        public double[,] MarkersInputData = new double[1000, 7];
        public double CountPrev;
        public bool flag_AccuracyClass_0_0grph;
        public double Imitator_GPS_PositionError;
        public bool flag_VupOdo_till_VupSINS;

        public static SINS_State DeepCopy(SINS_State other)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(ms, other);
                ms.Position = 0;
                return (SINS_State)formatter.Deserialize(ms);
            }
        }

    }


    public class ParamToStart
    {
        public double Experiment_Noise_Vel, Experiment_Noise_Angl;
        public double Experiment_stdR;
        public double Experiment_stdOdoR;
        public double Experiment_stdV;
        public double Experiment_stdScale;
        public double Experiment_stdKappa1;
        public double Experiment_stdKappa3;
        public bool Experiment_NoiseModelFlag;
        public double Experiment_GPS_PositionError;

        public bool Imitator_addNoisSample_DUS, Imitator_addNoisSample_ACCS;
        public string Imitator_addNoisSamplePath_DUS, Imitator_addNoisSamplePath_ACCS;
        public double Imitator_Noise_Vel, Imitator_Noise_Angl;
        public double Imitator_stdR;
        public double Imitator_stdOdoR;
        public double Imitator_stdV;
        public double Imitator_stdScale;
        public double Imitator_stdKappa1;
        public double Imitator_stdKappa3;
        public bool Imitator_NoiseModelFlag;
        public double Imitator_GPS_IsReadyDistance;
        public double Imitator_Noise_OdoScale;
        public double Imitator_Noise_OdoKappa;
        public double Imitator_Noise_Pos;
        public double Imitator_Noise_Drift;
        public double Imitator_Noise_Accel;
        public double Modeling_Params_OdoKappa1;
        public double Modeling_Params_OdoKappa3;
        public double Modeling_Params_OdoIncrement;
        public double Modeling_Params_OdoScaleErr;
        public int Modeling_Params_OdoFrequency;
        public double Modeling_Params_df_s;
        public double Modeling_Params_dnu_s;
        public double Imitator_GPS_PositionError;
    }

    public class Kalman_Vars
    {
        public int cnt_measures;
        public double DynamicNoiseFactor_f = 1e-5, DynamicNoiseFactor_nu = 1e-8, OdoNoise_V, OdoNoise_Dist;

        public double[] Measure = new double[SimpleData.iMz];
        public double[] Noize_Z = new double[SimpleData.iMz];

        public double[] ErrorConditionVector_m = new double[SimpleData.iMx], ErrorVector_m = new double[SimpleData.iMxSmthd];
        public double[] ErrorConditionVector_p = new double[SimpleData.iMx], ErrorVector_p = new double[SimpleData.iMxSmthd];
        public double[] StringOfMeasure = new double[SimpleData.iMx];
        public double[] KalmanFactor = new double[SimpleData.iMx];

        public double[] Matrix_A = new double[SimpleData.iMx * SimpleData.iMx];
        public double[] Matrix_H = new double[SimpleData.iMx * SimpleData.iMz];
        public double[] CovarianceMatrix_P = new double[SimpleData.iMx * SimpleData.iMx];

        public double[] CovarianceMatrixS_m = new double[SimpleData.iMx * SimpleData.iMx]
                      , CovarianceMatrix_SP_m = new double[SimpleData.iMxSmthd * SimpleData.iMxSmthd];

        public double[] CovarianceMatrixS_p = new double[SimpleData.iMx * SimpleData.iMx]
                      , CovarianceMatrix_SP_p = new double[SimpleData.iMxSmthd * SimpleData.iMxSmthd];

        public double[] CovarianceMatrixNoise = new double[SimpleData.iMx * SimpleData.iMq];
        public double[] TransitionMatrixF = new double[SimpleData.iMx * SimpleData.iMx];

        public double[] ErrorConditionVector_Straight = new double[SimpleData.iMx], ErrorVector_Straight = new double[SimpleData.iMxSmthd];
        public double[] ErrorConditionVector_Smoothed = new double[SimpleData.iMx], ErrorVector_Smoothed = new double[SimpleData.iMxSmthd];

        public double[] CovarianceMatrixS_Straight = new double[SimpleData.iMx * SimpleData.iMx]
                      , CovarianceMatrix_SP_Straight = new double[SimpleData.iMxSmthd * SimpleData.iMxSmthd];

        public double[] CovarianceMatrixS_Smoothed = new double[SimpleData.iMx * SimpleData.iMx]
                      , CovarianceMatrix_SP_Smoothed = new double[SimpleData.iMxSmthd * SimpleData.iMxSmthd];

        public double Noise_Pos, Noise_Drift, Noise_Accel, Noise_OdoScale, Noise_OdoKappa;
        public double[] Noise_Vel = new double[3];
        public double[] Noise_Angl = new double[3];

        public double OdoNoise_STOP;

        public double kappa1_est, kappa3_est;

        public class BufferArray
        {
            public int[] Count = new int[60];

            public double[] odometer_left = new double[60], odometer_right = new double[60];
            public int[] odo_left_IsReady = new int[60], odo_right_IsReady = new int[60];
            public int OdoTimeStepCount;
            public double OdometerLeftPrev, OdometerRightPrev;

            public double[,] V_x = new double[60, 3];
            public double[,] F_z = new double[60, 3];
            public double[,] W_z = new double[60, 3];
        }
    }

    public class Kalman_Align
    {
        public int cnt_measures;

        public double[] Noise_Vel = new double[3];
        public double[] Noise_Angl = new double[3];

        public double[] Measure = new double[SimpleData.iMz_Align];
        public double[] Noize_Z = new double[SimpleData.iMz_Align];

        public double[] ErrorConditionVector_m = new double[SimpleData.iMx_Align];
        public double[] ErrorConditionVector_p = new double[SimpleData.iMx_Align];
        public double[] StringOfMeasure = new double[SimpleData.iMx_Align];
        public double[] KalmanFactor = new double[SimpleData.iMx_Align];

        public double[] Matrix_A = new double[SimpleData.iMx_Align * SimpleData.iMx_Align];
        public double[] Matrix_H = new double[SimpleData.iMx_Align * SimpleData.iMx_Align];
        public double[] CovarianceMatrixS_m = new double[SimpleData.iMx_Align * SimpleData.iMx_Align];
        public double[] CovarianceMatrixS_p = new double[SimpleData.iMx_Align * SimpleData.iMx_Align];
        public double[] CovarianceMatrixNoise = new double[SimpleData.iMx_Align * SimpleData.iMq_Align];
        public double[] TransitionMatrixF = new double[SimpleData.iMx_Align * SimpleData.iMx_Align];
    }

    public class Proc_Help
    {
        public bool initCount = false;
        public string datastring;

        public double distance, distance_from_start;

        public double[] distance_GK_Sarat = new double[46];

        public double LatSNS, LongSNS, AltSNS, SpeedSNS, Ve_SNS, Vn_SNS;

        public int corrected = 0, AlgnCnt = 0;
    }
}

