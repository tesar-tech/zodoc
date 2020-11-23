title: Display Matlab buildin demo images
lead: Read and display all buildin Matlab images with its file names
Published: 2020-11-23
Tags: [matlab, montage, images,imageDatastore]
prerequisites: [Matlab]
Authors: tesar-tech
---

  
``` matlab
imds = imageDatastore( fullfile(matlabroot, '\toolbox\images\imdata'));%get images from path
imds.ReadFcn = @readWithFilename;%custom read function (to insert filename)
montage(imds)% display images

function img = readWithFilename(path)
img = imresize(mat2gray(imread(path)),[NaN 800]);% all images are roughtly same
[~,name,ext] = fileparts(path);% get file name
img = insertText(img,[1 1],[name,ext],'FontSize',80); % insert file name to image
end
```