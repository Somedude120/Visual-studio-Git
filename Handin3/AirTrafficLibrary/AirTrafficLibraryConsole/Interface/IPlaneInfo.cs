namespace AirTrafficLibrary.Interface
{
    public interface IPlaneInfo
    {
        string GetTag(string tag);
        string GetX(string xcoord);
        string GetY(string ycoord);
        string GetAlt(string altitude);
        string GetDate(string date);
    }
}