using System.ComponentModel.DataAnnotations;

namespace JohnGuidry.Models;

public class DevNotes
{
    public int Id { get; set; }
    [DataType(DataType.Date)] 
    public DateTime CreateDate { get; set; }
    public string? Notes { get; set; }

}
