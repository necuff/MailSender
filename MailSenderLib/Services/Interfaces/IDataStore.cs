using System.Collections.Generic;

namespace MailSenderLib.Services.Interfaces
{
    /// <summary>
    /// Хранилище объектов
    /// </summary>
    /// <typeparam name="T">Тип хранимого объекта</typeparam>
    public interface IDataStore<T>
    {
        /// <summary>
        /// Получить все объекты
        /// </summary>
        /// <returns>Перечисление объектов</returns>
        IEnumerable<T> GetAll();

        /// <summary>
        /// Получить объект по идентификатору
        /// </summary>
        /// <param name="id">Числовой идентификатор объекта в хранилище</param>
        /// <returns>Найденный объект, либо <see langword="null"/></returns>
        T GetByID(int id);

        /// <summary>
        /// Создать (добавить) объект в хранилище
        /// </summary>
        /// <param name="item">Создаваемый (добавляемый в хранилище) объект</param>
        /// <returns>Идентификатор, присвоенный хранилищем объекту</returns>
        int Create(T item);

        /// <summary>
        /// Отредактировать объект в хранилище
        /// </summary>
        /// <param name="id">Идентификатор объекта, который надо отредактировать</param>
        /// <param name="item">Данные, которые требуется передать в редактируемый объект</param>
        void Edit(int id, T item);

        /// <summary>
        /// Удаалть объект из хранилища по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор удаляемого объекта</param>
        /// <returns>Удаленный из хранилища объект, либо <see langword="null"/>, если объекта в хранилище не было</returns>
        T Remove(int id);

        /// <summary>
        /// Сохранить сделанные изменения
        /// </summary>
        void SaveChanges();
    }
}
