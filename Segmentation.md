title: Image_segmentation_by_k-means
# K means
k-means clustering is a partitioning method. The function kmeans partitions data into k mutually exclusive clusters, and returns the index of the cluster to which it has assigned each observation. Unlike hierarchical clustering, k-means clustering operates on actual observations (rather than the larger set of dissimilarity measures), and creates a single level of clusters. The distinctions mean that k-means clustering is often more suitable than hierarchical clustering for large amounts of data. Each cluster in the partition is defined by its member objects and by its centroid, or center. The centroid for each cluster is the point to which the sum of distances from all objects in that cluster is minimized. kmeans computes cluster centroids differently for each distance metric, to minimize the sum with respect to the measure that you specify.
# Loading image, convert to grayscale image
```matlab
I = imread('shapes.png'); % read image from graphics file
Image = {};
Image{1} =I;
Ag =imadjust( rgb2gray(I)); %specifying contrast limits for the input grayscale image
Image{2} =Ag;
```

# Binarization of the image
```matlab
Image{3} = imbinarize(Ag,'Adaptive','ForegroundPolarity','Dark','Sensitivity',0.55); % binarize 2-D grayscale image
% using adaptive thresholding, ForegroundPolarity parameter to indicate that the foreground is darker than the background,
% Sensitivity factor for adaptive thresholding a number in the range [0, 1]
Image{4} = imfill(~Image{end},'Holes'); % fill image regions and holes
Image{5} = imclearborder(Image{end}); % suppress structures connected to image border
```
# Extract objects from binary image
```matlab
Image{6} = bwareafilt(Image{end},[1000 Inf]); % extract objects from binary image by size
```
# K means
```matlab
reg_props = regionprops(Image{5},'area'); % measure properties of image regions
Areas =  cat(1,reg_props.Area);
hist(Areas,30)
[indx, Centers] = kmeans(Areas,3);
Min_max = min([max(Areas(indx==1)),max(Areas(indx==2)),max(Areas(indx==3)) ]);
Image{6} = bwareafilt(Image{5},[Min_max Inf]);
```
# Display image
```matlab
montage(Image,'BorderSize',[1 1],'BackgroundColor','Green') % file name, pads the image borders with the background color, create 1 by 1 image,
% BackgroundColor fills all blank spaces with this color, including the space specified by BorderSize
% if you specify a background color, then the montage function renders the output as an RGB image
```
