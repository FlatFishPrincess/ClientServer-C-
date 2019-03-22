using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoreControls
{
    /// <summary>
    /// Information regarding a postsecondary school.
    /// </summary>
    class School
    {
        public string Name { get; set; }                // School name
        public SchoolType SchoolType { get; set; }      // School type, see enum below
        public readonly int numberOfSchoolTypes =       // Just playing around to get the size of the enum
            sizeof(SchoolType);
        public uint Size { get; set; }                  // School enrolment

        /// <summary>
        /// Initialize School object
        /// </summary>
        /// <param name="name">School name</param>
        /// <param name="t">School type</param>
        /// <param name="size">School enrolment</param>
        public School(string name, SchoolType t, uint size)
        {
            Name = name;
            SchoolType = t;
            Size = size;
        }
        /// <summary>
        /// String that formats school name, type, and size together
        /// for easy display.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format($"{Name} Type:{SchoolType} Size: {Size:n0}");
        }
    }

    /// <summary>
    /// The types of postsecondary schools
    /// </summary>
    public enum SchoolType { University, College, Technical, Vocational };

}
