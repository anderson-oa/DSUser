pipeline {
    agent any
    stages {
        stage('Build') {
            steps {
                sh 'dotnet clean'
                sh 'dotnet restore'
                sh 'dotnet build'
            }
        }
        stage('Test') {
            steps {
                echo 'Testing...'
            }
        }
         stage('Image') {
            steps {
                sh 'docker build -t dsuser .'
            }
        }
    }
}