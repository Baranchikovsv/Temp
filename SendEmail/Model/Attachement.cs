using System;
using System.IO;

namespace SendEmail.Model
{
   
    public class Attachement
    {
        #region Properties

        /// <summary>
        /// Attachement name
        /// </summary>
        public string Name { get; internal set; }

        /// <summary>
        /// File name
        /// </summary>
        public string FileName { get; internal set; }

        /// <summary>
        /// File data
        /// </summary>
        public byte[] FileData { get; internal set; }

        /// <summary>
        /// Content type
        /// </summary>
        public string ContentType { get; set; }

        /// <summary>
        /// Data type
        /// </summary>
        public DataType DataType { get; internal set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="name"></param>
        /// <param name="fileName"></param>
        public Attachement(string name, string fileName)
        {
            Name = name;
            FileName = fileName;
            DataType = DataType.File;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="name"></param>
        /// <param name="fileData"></param>
        public Attachement(string name, byte[] fileData)
        {
            Name = name;
            FileData = fileData;
            DataType = DataType.Data;
        }

        #endregion
    }
}