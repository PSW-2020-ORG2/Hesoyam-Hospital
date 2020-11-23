using Backend.Model.PatientModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Documents
{
    public class DocumentsMapper
    {
        public static DocumentDTO DocumentToDocumentDTO(Document document)
        {
            return new DocumentDTO(document.DateCreated, document.Doctor.FullName, document.Diagnosis.diagnosisName);
        }
    }
}
