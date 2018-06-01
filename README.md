# Comercio

## Acciones para actualizar el reporsitorio

1.-  abrir el comando git
2.- Ir a la carpeta del repositorio
```batch
cd ..
cd Diego
cd sources
cd Comercio
```
3.- Chequeamos el estado de git
```batch
git status
```
4.- Agregamos todos los cambios realizados ( parámetro `-A` agrega archivos nuevos, modificados, eliminados)
```batch
git add -A
```
5.- Commiteamos los cambios al repositorio
```batch
git commit -m '¡qué bonito quedó!'
```
6.- subimos los cambios al master (servidor original)
```batch
git push origin master
```
