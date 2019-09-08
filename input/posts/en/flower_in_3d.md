title: Flower in 3D
lead: Convert color to third dimension
Published: 08/09/2019
Tags: [matlab, colors, 3D]
datazooFiles: imgs/kytka256.jpg
prerequisites: Matlab
Authors: tesar-tech
---

Usage of `mesh` function in matlab to display image of flower in 3D. Brighter locations are displayed as higher peaks. Color of mesh depends on used colormap (parula for this image).

``` matlab
A = imread('kytka256.jpg');
Ag = rgb2gray(A);
mesh(Ag)
axis off;
axis vis3d;grid off

while(true)%% bude se točit pořád
    for ii = 1:360
        view(ii,45)
        pause(0.01)
    end
end
```