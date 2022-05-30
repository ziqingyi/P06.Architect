namespace P06.BlazorServerApp.Configuration
{
    public class ColumnDefinition
    {
        public ColumnDefinition()
        {
            this.DataType = DataType.NotSet;
            this.Alignment = Alignment.NotSet;
        }

        public string DataField { get; set; }

        public string Caption { get; set; }

        public DataType DataType { get; set; }

        public string Format { get; set; }

        public Alignment Alignment { get; set; }

    }
}
