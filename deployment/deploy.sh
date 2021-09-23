# Create Resource Group for all deployments
az group create -n graphql-serverless -l westeurope
# Deploy ARM template creating all required resources
az deployment group create -g graphql-serverless -n srvless -f AzureDeploy.json --parameters @AzureDeploy.parameters.json
# Initialize serverless database with schema and data
sqlpackage.exe /Action:Import /tsn:tcp:<servername>.database.windows.net,1433 /tdn:WideWorldImporters /tu:<username> /tp:<password> /sf:../db/WideWorldImporters-Standard.bacpac /p:Storage=File
# Create Azure Container Instance deployment of GraphQL service
az container create --resource-group graphql-serverless --name graphql --image docker.io/scoriani/graphql --dns-name-label graphqlaci --ports 80 --environment-variables 'CONNSTR'='<connection string>'
# Deploy Azure Function local project
func azure functionapp publish graphql-serverless-func