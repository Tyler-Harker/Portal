﻿using Portal.Domain.ValueObjects.Organizations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Domain.Responses.Organizations
{
    public record GetOrganizationMsalConfigurationResponse(Authority Authority, ClientId ClientId);
}