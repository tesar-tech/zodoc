title: Flower in 3D
lead: Convert color to third dimension
Published: 2019-09-08
Tags: [matlab, colors, 3D, mesh]
datazooFiles: imgs/kytka256.jpg
prerequisites: Matlab
Authors: tesar-tech
---

Usage of `mesh` function in matlab to display image of flower in 3D. Brighter locations are displayed as higher peaks. Color of mesh depends on used colormap (parula for this image).

``` matlab
A = imread('kytka256.jpg');
Ag = rgb2gray(A);%convert to gray
mesh(Ag) 
axis off;axis vis3d;grid off

while(true)%% infinite loop
    for ii = 1:360 %change azimuth of view from 1 ° to 360 °
        view(ii,45) % set elevation of view to 45 °
        pause(0.01) % wait 10 miliseconds
    end
end
```