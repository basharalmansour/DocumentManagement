using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CleanArchitecture.Domain.Common;

namespace CleanArchitecture.Application.Common.Helpers;

/// <summary>
/// it is used to compare two list, a database list and a dto list, so it add remove and edit the database list records
/// </summary>
public class ListComparer
{
    public static void UpdateListByList<RequestListObject, DatabaseListObject>(
        IList<DatabaseListObject> databaseList,
        IList<RequestListObject> requestList,
        string databaseNameOfForeignKey,
        string requestNameOfForeignKey,
        IMapper mapper)
        where RequestListObject : IEntity<int>, IConvertible
        where DatabaseListObject : class, IEntity<int>
    {
        //to edit
        var recordsToEdit = requestList.Where(x => databaseList.Select(j => j.GetType().GetProperty(databaseNameOfForeignKey).GetValue(j, null)).Contains(x.GetType().GetProperty(requestNameOfForeignKey).GetValue(x, null))).ToList();

        foreach (var record in recordsToEdit)
        {
            var recordToEdit = databaseList.FirstOrDefault(x => x.GetType().GetProperty(databaseNameOfForeignKey).GetValue(x, null) == record.GetType().GetProperty(requestNameOfForeignKey).GetValue(record, null));
            recordToEdit = mapper.Map<DatabaseListObject>(record);
        }
        //to add
        var recordsToAdd = requestList.Where(x => !databaseList.Select(j => j.GetType().GetProperty(databaseNameOfForeignKey).GetValue(j, null)).Contains(x.GetType().GetProperty(requestNameOfForeignKey).GetValue(x, null))).ToList();
        foreach (var record in recordsToAdd)
        {
            databaseList.Add(mapper.Map<DatabaseListObject>(record));
        }
        //to delete
        var recordsToDelete = databaseList.Where(x => !requestList.Select(j => j.GetType().GetProperty(requestNameOfForeignKey).GetValue(j, null)).Contains(x.GetType().GetProperty(databaseNameOfForeignKey).GetValue(x, null))).ToList();
        foreach (var record in recordsToDelete)
        {
            if (record.GetType().GetProperty("IsDeleted") == null)
                databaseList.Remove(record);
            else
                record.GetType().GetProperty("IsDeleted").SetValue(record, true);
        }


        ////to edit
        //var documentsToEdit = request.Documents.Where(x => editedCategory.Documents.Select(j => j.DocumentTemplateId).Contains(x.DocumentTemplateId)).ToList();
        //foreach (var document in documentsToEdit)
        //{
        //    var documentToEdit = editedCategory.Documents.FirstOrDefault(x => x.DocumentTemplateId == document.DocumentTemplateId);
        //    documentToEdit = _mapper.Map<CategoryDocument>(document);
        //}
        ////to add
        //var documentsToAdd = request.Documents.Where(x => !editedCategory.Documents.Select(j => j.DocumentTemplateId).Contains(x.DocumentTemplateId)).ToList();
        //foreach (var document in documentsToAdd)
        //{
        //    editedCategory.Documents.Add(_mapper.Map<CategoryDocument>(document));
        //}
        ////to delete
        //var documentsToDelete = editedCategory.Documents.Where(x => !request.Documents.Select(j => j.DocumentTemplateId).Contains(x.DocumentTemplateId)).ToList();
        //foreach (var document in documentsToDelete)
        //{
        //    editedCategory.Documents.Remove(document);
        //}
    }

    public static void UpdateListByEnum<RequestListObject, DatabaseListObject>(
        IList<DatabaseListObject> databaseList,
        IList<RequestListObject> requestList,
        string databaseNameOfForeignKey,
        IMapper mapper)
        where RequestListObject : Enum
        where DatabaseListObject : class, IEntity<int>
    {
        //to edit
        var recordsToEdit = requestList.Where(x => databaseList.Select(j => j.GetType().GetProperty(databaseNameOfForeignKey).GetValue(j, null)).Contains(x)).ToList();
        foreach (var record in recordsToEdit)
        {
            var recordToEdit = databaseList.FirstOrDefault(x => EqualityComparer<RequestListObject>.Default.Equals((RequestListObject)(x.GetType().GetProperty(databaseNameOfForeignKey).GetValue(x, null)), record));
            recordToEdit = mapper.Map<DatabaseListObject>(record);
        }
        //to add
        var recordsToAdd = requestList.Where(x => !databaseList.Select(j => j.GetType().GetProperty(databaseNameOfForeignKey).GetValue(j, null)).Contains(x)).ToList();
        foreach (var record in recordsToAdd)
        {
            databaseList.Add(mapper.Map<DatabaseListObject>(record));
        }
        //to delete
        var recordsToDelete = databaseList.Where(x => !requestList.Contains((RequestListObject)x.GetType().GetProperty(databaseNameOfForeignKey).GetValue(x, null))).ToList();
        foreach (var record in recordsToDelete)
        {
            if (record.GetType().GetProperty("IsDeleted") == null)
                databaseList.Remove(record);
            else
                record.GetType().GetProperty("IsDeleted").SetValue(record, true);
        }

    }
}
