using System.ComponentModel.DataAnnotations;

#pragma warning disable CS8618
namespace Clean.Code.Part1.Samples
{
    // Problems:
    // - CTOR kicks highlander principle -> it can be only 1 ctor method which sets the state of the object
    // - Logic in a data object which should be pure POCO object
    // - Object A knows Object B - imagine object B is in a different namespace or
    //   3rd party library then you have an unwanted reference at this scope !
    // - Properties are mutable !
    // - When the mapping should changed you have changes at this file. This should not be the case !

    // What would happen if another DEV need a convert method to convert to Object C, what does he do if he seen the
    // code ??
    // 
    // Broken window:
    // - He would extend the object with another ComvertToC method
    //
    // Path finder:
    // - The dev would extract the convert logic out into a dedicated mapper function
    // - The dev would also create for his new mapping task his needed mapping function
    // - The dev would cleanup the data to a pure POCO with record type notation
    // - The dev hopes that all needed tests for the program was written that he can do this refactoring :)
    public class ObjectA
    {
        private string _propertyB;

        public ObjectA() : this(string.Empty)
        {
        }

        public ObjectA(string propertyA)
        {
            PropertyA = propertyA;
        }

        public string PropertyA { get; set; } = string.Empty;

        public string PropertyB
        {
            get => _propertyB;

            set
            {
                _propertyB = value;
            }
        }

        public ObjectB ConvertToB()
        {
            return new ObjectB()
            {
                PropertyA = PropertyB,
                PropertyB = PropertyA
            };
        }
    }

    public class ObjectB
    {
        public string PropertyA { get; set; }
        public string PropertyB { get; set; }
    }
}

#pragma warning restore CS8618
