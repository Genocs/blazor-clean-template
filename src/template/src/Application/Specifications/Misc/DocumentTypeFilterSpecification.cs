﻿using GenocsBlazor.Application.Specifications.Base;
using GenocsBlazor.Domain.Entities.Misc;

namespace GenocsBlazor.Application.Specifications.Misc
{
    public class DocumentTypeFilterSpecification : GenocsSpecification<DocumentType>
    {
        public DocumentTypeFilterSpecification(string searchString)
        {
            if (!string.IsNullOrEmpty(searchString))
            {
                Criteria = p => p.Name.Contains(searchString) || p.Description.Contains(searchString);
            }
            else
            {
                Criteria = p => true;
            }
        }
    }
}