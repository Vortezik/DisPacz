# Czyszczenie projektu React Native + .NET przed pakowaniem
# Uruchom z głównego folderu projektu

Write-Host "🧹 Czyszczenie projektu..." -ForegroundColor Cyan

# React Native
$rnPath = "rn\SolutionOrdersMobile"

Write-Host "Usuwanie node_modules..." -ForegroundColor Yellow
cmd /c "rd /s /q $rnPath\node_modules" 2>$null

Write-Host "Usuwanie Android cache..." -ForegroundColor Yellow
Remove-Item -Path "$rnPath\android\.gradle" -Recurse -Force -ErrorAction SilentlyContinue
Remove-Item -Path "$rnPath\android\build" -Recurse -Force -ErrorAction SilentlyContinue
Remove-Item -Path "$rnPath\android\app\build" -Recurse -Force -ErrorAction SilentlyContinue
Remove-Item -Path "$rnPath\android\app\.cxx" -Recurse -Force -ErrorAction SilentlyContinue

Write-Host "Usuwanie iOS cache..." -ForegroundColor Yellow
Remove-Item -Path "$rnPath\ios\Pods" -Recurse -Force -ErrorAction SilentlyContinue
Remove-Item -Path "$rnPath\ios\build" -Recurse -Force -ErrorAction SilentlyContinue

Write-Host "Usuwanie Metro cache..." -ForegroundColor Yellow
Remove-Item -Path "$rnPath\.metro" -Recurse -Force -ErrorAction SilentlyContinue

# .NET
$dotnetPath = "dotnet\SolutionOrdersReact.Server"

Write-Host "Usuwanie .NET bin/obj..." -ForegroundColor Yellow
Remove-Item -Path "$dotnetPath\bin" -Recurse -Force -ErrorAction SilentlyContinue
Remove-Item -Path "$dotnetPath\obj" -Recurse -Force -ErrorAction SilentlyContinue

# Oblicz rozmiar
$size = (Get-ChildItem -Recurse -File -ErrorAction SilentlyContinue | 
    Measure-Object -Property Length -Sum).Sum / 1MB

Write-Host ""
Write-Host "✅ Gotowe! Rozmiar projektu: $([math]::Round($size, 2)) MB" -ForegroundColor Green