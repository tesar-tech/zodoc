title: Souhvězdí velkého vozu za použítí scatteru v MATLABu
lead: Vykreslí hvězdy podle jejich svítivosti, názvy i konturu souhvězdí 
Published: 2019-09-15
Tags: [matlab, scatter]
prerequisites: Matlab
Authors: tesar-tech
---
Proměnná `m` znamená [hvězdnou velikost](https://cs.wikipedia.org/wiki/Hvězdná_velikost).

``` matlab
nazvy_hvezd = {'Merak', 'Dubhe','Phecda','Megrez','Alioth','Mizar','Alkaid'};
m = [2.37, 1.79, 2.44, 3.312, 1.77, 3.88 ,1.86];
I0 = 500;
svetelny_tok =power(10, -m/2.5 + log10(I0));

x = [337,316,249,205,146,83,29]; %pozice hvezd z obrazku
y = [147,205,103,151,131,125,65];

scatter(x,y,svetelny_tok,'w*')

axis([0,384,0,285]);
set(gca,'Color','k','XTick',[],'YTick',[])
text(x+5,y-4,nazvy_hvezd,'Color',[0 1 0.8],'FontSize',8)
hold on;
poradi = [4,3,1,2,4,5,6,7];
plot(x(poradi),y(poradi),'LineWidth',1)
pbaspect([348 285 1])%udrzi pomer stran
```