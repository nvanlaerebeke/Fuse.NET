pipeline {
  parameters { booleanParam(name: 'PUBLISH', defaultValue: false, description: 'Will push the package to the nuget repository, note that overwriting version does not work') }
  agent {
    docker {
      image "mcr.microsoft.com/dotnet/sdk:6.0"
    }
  }
  options {
    skipStagesAfterUnstable()
  }
  environment {
    REGISTRY = "https://nuget.crazyzone.be/v3/index.json"
    NUGET_API_KEY = credentials('nuget-api-key')
  }
  stages {
    stage('build') {
      steps {
        sh '''#!/bin/bash
make build
        '''
      }
    }
    stage('push') {
      when { anyOf {
        expression{params.PUBLISH == true }
      } }
      steps {
        sh '''#!/bin/bash
make push REGISTRY="$REGISTRY" APIKEY="$NUGET_API_KEY"
        '''
      }
    }
  }
}
