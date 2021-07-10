namespace hepsiburada.MarsRover
{
    public static class ScreenMessages
    {
        public const string ASK_PLATEAU_SIZE = "Please enter plateau size:";
        public const string ASK_ROVER_COORDINATE = "Please enter {0}. rover's coordinate and direction:";
        public const string ASK_ROVER_MOVEMENTS = "Please enter {0}. rover's instructions:";
        public const string ASK_TO_STOP = "Stop and calculate (press y/Y) or press any other key to add new rover?";

        // Validation Messages
        public const string PLATEAU_SIZE_INPUT_INVALID= "Plateau size data is not valid!";
        public const string PLATEAU_SIZE_NOT_BE_ZERO = "Plateau size can not be (x,0) or (0,y)";
        public const string ROVER_COORDINATE_ERROR = "Coordinate data is not valid!";
        public const string ROVER_INSTRUCTIONS_ERROR = "Instruction data is not valid!";
        public const string COORDINATE_X_AXIS_OUT_BOUNDRY = "X axis of given coordinate is outside of plateau boundry";
        public const string COORDINATE_Y_AXIS_OUT_BOUNDRY = "Y axis of given coordinate is outside of plateau boundry";
    }
}
