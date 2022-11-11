﻿using Portal.Domain.ValueObjects;
using Portal.Domain.ValueObjects.Security;
using Portal.Web.Domain.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Web.App.Shared.Stores.OrganizationRolesTableUseCase
{
    public record OrganizationRolesTableState(Page<Role>? Page = null, bool IsLoading = false, string? ErrorMessage = null) : BaseState(IsLoading, ErrorMessage), ITableState<Role>;
}
