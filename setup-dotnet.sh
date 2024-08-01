#!/bin/bash

# .NET SDK ve Runtime Kurulumu

# Versiyonları kontrol et ve kurulumu gerçekleştir
echo "Dotnet SDK ve Runtime kurulumu başlatılıyor..."

# Dotnet SDK 7.0 ve 6.0 versiyonları için kurulum
DOTNET_SDK_VERSION="7.0"
DOTNET_SDK_VERSION_OLD="6.0"

# Dotnet SDK kurulum
curl -o dotnet-sdk.tar.gz https://download.visualstudio.microsoft.com/download/pr/7e5c7410-54f5-452d-a9e6-30658a144c9b/7a5b8309a14e006d80b9c6b6c62b1c38/dotnet-sdk-${DOTNET_SDK_VERSION}-linux-x64.tar.gz
mkdir -p $HOME/dotnet && tar zxf dotnet-sdk.tar.gz -C $HOME/dotnet
export DOTNET_ROOT=$HOME/dotnet
export PATH=$PATH:$HOME/dotnet

# Dotnet SDK ve Runtime kurulumunu doğrulama
dotnet --version
dotnet --list-sdks
dotnet --list-runtimes

# PostgreSQL Bağımlılıklarını Kurma
echo "PostgreSQL Bağımlılıkları kurulumu başlatılıyor..."
dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL

# Entity Framework Core Bağımlılıklarını Kurma
echo "Entity Framework Core bağımlılıkları kurulumu başlatılıyor..."
dotnet add package Microsoft.EntityFrameworkCore
dotnet add package Microsoft.EntityFrameworkCore.Design

# Diğer gerekli bağımlılıklar (Opsiyonel)
# dotnet add package [PackageName]

# Projeyi güncelleme ve bağımlılıkları yükleme
echo "Projeyi güncelleme ve bağımlılıkları yükleme başlatılıyor..."
dotnet restore

echo "Kurulum tamamlandı!"
