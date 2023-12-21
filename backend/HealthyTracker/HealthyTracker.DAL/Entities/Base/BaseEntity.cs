using System.ComponentModel.DataAnnotations;

namespace HealthyTracker.DAL.Entities.Base;

public abstract class BaseEntity<T> where T : IEquatable<T>
{
    [Key]
    public T Id { get; set; } = default!;
}