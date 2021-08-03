namespace FiguresDictionary
{
    public class Figure
    {
        public int SideNumber { get; set; }

        public int SideLength { get; set; }


        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            if (!(obj is Figure))
                return false;
            var figure = (Figure)obj;
            return figure.SideNumber == SideNumber && figure.SideLength==SideLength;
        }

        public static bool operator ==(Figure figure1, Figure figure2)
        {
            return figure1.Equals(figure2);
        }

        public static bool operator !=(Figure figure1, Figure figure2)
        {
            return !figure1.Equals(figure2);
        }
        public override int GetHashCode()
        {
            return SideNumber+SideLength;
        }
    }
}
