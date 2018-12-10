title: Detect which image is sharper
lead: Using edge detection to decide which image is sharper
published: 2018-11-04
Tags: [matlab,edges, binary image, sharpness]
datazooFiles: imgs/kytka256.jpg,
prerequisites: Matlab
---

``` matlab
A=imread('kytka256.jpg');

A_blurred=imgaussfilt(A,10); % create blurred image 

% 'edge' detects edges in the image, returns a binary image
A_blurred_E=edge(rgb2gray(A_blurred));
A_E=edge(rgb2gray(A));

% just need to compare which matrix contains more ones
if (sum(A_E(:))>sum(A_blurred_E(:)))
    A = insertText(A,[1 1],'sharper','FontSize',22);
elseif (length(C)<length(B))
  A_blurred = insertText(A_blurred,[1 1],'sharper','FontSize',22);
end

montage({A,A_blurred,A_E,A_blurred_E})
 ```
