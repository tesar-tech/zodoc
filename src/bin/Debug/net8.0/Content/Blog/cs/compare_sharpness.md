title: Detekce ostřejšího obrázku
lead: Použití detekce hran pro porovnání ostrosti obrazu
published: 2018-11-04
Tags: [matlab,edges, binary image, sharpness]
datazooFiles: imgs/kytka256.jpg,
prerequisites: Matlab
Authors: tesar-tech
---

``` matlab
A=imread('kytka256.jpg');

A_blurred=imgaussfilt(A,10); % vytvoří rozostřený obrázek

% 'edge' detekuje hrany, vrací binární obr.
A_blurred_E=edge(rgb2gray(A_blurred));
A_E=edge(rgb2gray(A));

% stačí proovnat, která matice obsahuje více jedniček
if (sum(A_E(:))>sum(A_blurred_E(:)))
    A = insertText(A,[1 1],'sharper','FontSize',22);
elseif (length(C)<length(B))
  A_blurred = insertText(A_blurred,[1 1],'sharper','FontSize',22);
end

montage({A,A_blurred,A_E,A_blurred_E})
 ```
