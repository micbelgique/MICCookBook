using System;
using MICCookBook.Web.Models;

namespace MICCookBook.Web.BusinessLayer.Exceptions
{
    public interface IEntityNotFoundException { }
    public class EntityNotFoundException<T, TKey> : Exception, IEntityNotFoundException where T : IIdentifiable<TKey>
    {
        public T Entity { get; set; }
        public TKey Id { get; set; }
        public Type EntityType { get; set; }

        public EntityNotFoundException(T entity) : this(entity.Id, typeof(T))
        {
            Entity = entity;
        }

        public EntityNotFoundException(TKey id, Type entityType) :
            base($"L'object de type {entityType} et d'Id {id} n'existe pas dans le contexte actuel.")
        {
            Id = id;
            EntityType = entityType;
        }
    }
}