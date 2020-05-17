namespace ClassesAndObjects
{
    public class Box
    {
        public double Length { get; set; }
        public double Height { get; set; }
        public double Width { get; set; }

        public double GetVolume()
        {
            return Length * Width * Height;
        }

        // create a function for Area.
    }



}