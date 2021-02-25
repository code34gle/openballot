namespace OB.Data
{
    public class ApiResult
    {
        //------------------------------------------
        public bool Success { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
        public long Miliseconds { get; set; }
        //----------------------------------------------------
        public void SetSuccess(string Message)
        {
            this.Success = true;
            this.Message = Message;
        }
        //----------------------------------------------------
        public void SetSuccess(string Message, object Data)
        {
            this.Success = true;
            this.Message = Message;
            this.Data = Data;
        }
        //----------------------------------------------------
        public void SetSuccess(string Message, object Data, long Miliseconds)
        {
            this.Success = true;
            this.Message = Message;
            this.Data = Data;
            this.Miliseconds = Miliseconds;
        }
        //----------------------------------------------------
        //----------------------------------------------------
        public void SetFailure(string Message)
        {
            this.Success = false;
            this.Message = Message;
        }
        //----------------------------------------------------
        public void SetFailure(string Message, object Data)
        {
            this.Success = false;
            this.Message = Message;
            this.Data = Data;
        }
        //----------------------------------------------------
        public void SetFailure(string Message, object Data, long Miliseconds)
        {
            this.Success = false;
            this.Message = Message;
            this.Data = Data;
            this.Miliseconds = Miliseconds;
        }
        //----------------------------------------------------
    }
}
