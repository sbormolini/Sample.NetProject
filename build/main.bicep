@description('The Azure region into which the resources should be deployed.')
param location string = resourceGroup().location

module app 'modules/cdb-serverless-rbac.bicep' = {
  name: 'cosmosDB-deployment'
  params: {
    accountName: 'cdb-bos-biceptest-chn-dev01'
    databaseName: 'cosmicworks'
    containerName: 'products'
    roleDefinitionId: '/subscriptions/7592bc29-9b3d-4294-aaf4-fd6df4883836/resourceGroups/arg-bos-biceptest-chn-dev01/providers/Microsoft.DocumentDB/databaseAccounts/cdb-bos-biceptest-chn-dev01/sqlRoleDefinitions/00000000-0000-0000-0000-000000000002'
    principalId: '93d19778-9975-4b28-aed9-2956d6c68e47'
    location: location
  }
}

