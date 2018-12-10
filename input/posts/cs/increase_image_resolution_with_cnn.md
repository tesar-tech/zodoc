title: Zvýšení rozlišení obrazu pomocí konvoluční neuronové sítě
lead: Testování neuronové sítě VDSR.
Published: 2018-10-13
Tags: [matlab, super-resolution, vdsr]
datazooFiles: imgs/kytka256.jpg
prerequisites: Matlab
---
*skutečné výsledky jsou mírně odlišné kvůli konverzi na gif*

Toto je test metody popsané v [dokumentaci matlabu](https://www.mathworks.com/help/images/single-image-super-resolution-using-deep-learning.html). Mírné zlepšení v kvalitě obrázku můžete vidět po bikubické interpolaci.

``` matlab
%% import předtrénované sítě poskytované matlabem
load('trainedVDSR-Epoch-100-ScaleFactors-234.mat');

%% připravení obrázku
A_ref = im2double(imresize(imread('imgs/kytka256.jpg'),[255 255]));
scaleFactor = 3;
A = imresize(A_ref,1/scaleFactor);
A_bicubic = imresize(A,scaleFactor,'bicubic');

%% vytvoření HR obrázku (obrázku s vysokým rozlišením) pomocí VDSR
A_ycbcr = rgb2ycbcr(A_bicubic);% převod do barevného modelu Ycbcr
% Rekonstrukce se provádí pouze na jasovém kanálu
A_residual = activations(net,A_ycbcr(:,:,1),41);% první kanál je Y(jas)

A_y_vsdr = A_ycbcr(:,:,1)+A_residual;% Y kanál pomocí vdsr
A_vdsr = ycbcr2rgb(cat(3,A_y_vsdr,A_ycbcr(:,:,2),A_ycbcr(:,:,3)));% převod zpět na rgb

%% přidání textu a přehrátí ve formě videa
Movie(:,:,:,1) =insertText(A_bicubic,[1 1],'HR pomocí bikubické interpolace','TextColor','white','BoxOpacity',0); 
Movie(:,:,:,2) =insertText(A_vdsr,[1 1],'HR pomocí VDSR','TextColor','white','BoxOpacity',0); 
Movie(:,:,:,3) =insertText(A_ref,[1 1],'Referenční obrázek','TextColor','white','BoxOpacity',0); 
implay(Movie,1);
```