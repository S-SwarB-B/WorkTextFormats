using TextFormats.NavigateFormats.CSV_Format;
using TextFormats.NavigateFormats.TXT_Format;
using TextFormats.WorkPerson;
namespace TextFormats.Test
{
    public class TestTextFormats
    {
        [Fact]
        public void TestWritePersonTXT()
        {
            CommonTextFormat commonTextFormat = new CommonTextFormat();
            Person person = new Person(1,"1", "1", "1", "1");
            int expected = 1;
            int actual = commonTextFormat.GeneralizedMethodWriting(@"1.txt", person);

            Assert.Equal(expected, actual);
        }
        [Fact]
        public void TestReadPersonCSV()
        {
            CommonTextFormat commonTextFormat = new CommonTextFormat();
            CSVTextFormat cSVTextFormat = new CSVTextFormat();
            string expected = commonTextFormat.GeneralizedMethodReading(@"1.csv").ToString();
            string person = cSVTextFormat.CsvMethodReading(@"1.csv").ToString();
            Assert.Equal(expected, person);
        }
    }
}