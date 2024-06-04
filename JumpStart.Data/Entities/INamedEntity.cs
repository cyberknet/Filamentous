using System.ComponentModel.DataAnnotations;

namespace JumpStart.Data.Entities;

public interface INamedEntity
{
    string Name { get; set; }
}
