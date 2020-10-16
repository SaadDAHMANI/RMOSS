/*
 * Created by SharpDevelop.
 * User: Saad
 * Date: 01/11/2015
 * Time: 12:27
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.IO;
using System.Xml;
using System.Xml.Linq;

namespace IOOperations.Components
{
	/// <summary>
	/// RMOSProject: The RMOS project model.
	/// </summary>	
    /// 
    public class RmosProject
    {
        public RmosProject()
        { }
        public RmosProject(string fileName)
        { }

        string mName = "Project";
       public string Name
       {
           get { return mName; }
           set
           {
               if (value == string.Empty)
               { mName = "n/a"; }
               else
               {
                   mName = value;
               }
           }
       }

       string mDescription = "n/a";
       public string Description
       {
           get { return mDescription; }
           set {
               if (value == string.Empty)
               { mDescription = "n/a"; }
               else
               {
                   mDescription = value;
               }
           }
       }

        string mProjectFileName = "n/a";
        public string ProjectFileName
        {
            get { return mProjectFileName; }
            set
            {
                if (value == string.Empty)
                { mProjectFileName = "n/a"; }
                else
                {
                    mProjectFileName = value;
                }
            }
        }

        string mReservoirFileName = "n/a";
        public string ReservoirFileName
        {
            get { return mReservoirFileName; }
            set
            {
                if (value == string.Empty)
                { mReservoirFileName = "n/a"; }
                else
                {
                    mReservoirFileName = value;
                }
            }
        }

        string mHVCurveFileName = "n/a";
        public string HVCurveFileName
        { get { return mHVCurveFileName; }
            set { 
                if (value == string .Empty )
                { mHVCurveFileName = "n/a"; }
                else
                { mHVCurveFileName = value; }
            }
        }

		string mHSCurveFileName = "n/a";
		public string HSCurveFileName
		{
			get { return mHSCurveFileName; }
			set
			{
				if (value == string.Empty)
				{ mHSCurveFileName = "n/a"; }
				else
				{ mHSCurveFileName = value; }
			}
		}

		string mEvaporationCurveFileName = "n/a";
		public string EvaporationCurveFileName
		{
			get { return mEvaporationCurveFileName; }
			set
			{
				if (value == string.Empty)
				{ mEvaporationCurveFileName = "n/a"; }
				else
				{ mEvaporationCurveFileName = value; }
			}
		}

		string mInfiltrationCurveFileName = "n/a";
		public string InfiltrationCurveFileName
		{
			get { return mInfiltrationCurveFileName; }
			set
			{
				if (value == string.Empty)
				{ mInfiltrationCurveFileName = "n/a"; }
				else
				{ mInfiltrationCurveFileName = value; }
			}
		}

		string mObjectifFunctionFileName = "n/a";
        public string ObjectifFunctionFileName
       {
           get { return mObjectifFunctionFileName; }
           set
           {
               if (value == string.Empty)
               { mObjectifFunctionFileName = "n/a"; }
               else
               {
                   mObjectifFunctionFileName = value;
               }
           }
       }

        string mInflowSeriesFileName = "n/a";
        public string InflowSeriesFileName
       {

       get {return mInflowSeriesFileName ;}
           set
           {
               if (value == string.Empty)
               { mInflowSeriesFileName = "n/a"; }
               else {
                   mInflowSeriesFileName = value;
               }}
           }

		string mDemandSeriesFileName = "n/a";
		public string DemandSeriesFileName
		{

			get { return mDemandSeriesFileName; }
			set
			{
				if (value == string.Empty)
				{ mDemandSeriesFileName = "n/a"; }
				else
				{
					mDemandSeriesFileName = value;
				}
			}
		}
		
		public bool Save()
     { 
        bool result = false;
        if (File.Exists (this .ProjectFileName ))
        //{
            using (FileStream fs = File.Open(this.mProjectFileName , FileMode.OpenOrCreate))
            {
                using (StreamWriter  strmWriter = new StreamWriter (fs))
                {
						strmWriter.WriteLine(this.Name);
						strmWriter.WriteLine(this.ProjectFileName);
						strmWriter.WriteLine(this.ReservoirFileName );
						strmWriter.WriteLine(this.DemandSeriesFileName);
						strmWriter.WriteLine(this.EvaporationCurveFileName);
						strmWriter.WriteLine(this.HSCurveFileName);
						strmWriter.WriteLine(this.HVCurveFileName);
						strmWriter.WriteLine(this.InfiltrationCurveFileName);
						strmWriter.WriteLine(this.InflowSeriesFileName);
						strmWriter.WriteLine(this.ObjectifFunctionFileName);
												
						strmWriter.Flush();
                       strmWriter.Close();
                    result = true;
                }
            }
        
        
        
        //}
        //else
        //{ throw new FileNotFoundException(this.mProjectFileName ); }
        return result;
    }


    }


}

