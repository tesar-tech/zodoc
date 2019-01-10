
title: # Generování náhodných hvězdiček
---
# Úkol
 Snažíme vytvořit hvězdičky různých velikostí a rotací. Hvězdička bude pravidelná, pěticípá.
# 
function CreatePoly()
  figure();
    for i=1:5
        [x,y]=CreatePoly();
        plotc(x,y);
        hold on;
    end        
end
function [x,y]=CreatePoly()
    numOfPoints = 5;
    degrees=2*pi/numOfPoints;
    theta=0:degrees:360-degrees 
    theta = sort(theta);
    rho = randi(200,size(theta));
    [x,y] = pol2cart(theta,rho);    
    xCenter = randi([-1000 1000]);
    yCenter = randi([-1000 1000]);
    x = x + xCenter;
    y = y + yCenter;    
end
function plotc(x,y,varargin)
    x = [x(:) ; x(1)];
    y = [y(:) ; y(1)];
    plot(x,y,varargin{:})
end
