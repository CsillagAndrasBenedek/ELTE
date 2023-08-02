% A -2, -1, 0, 1 alappontokon a -1, 0, 1, 0 értéket felvevő függvényt közelítsük
% természetes peremfeltételű harmadfokú spline-nal.
% A spline-t a globális bázisban írjuk fel (egyoldali hatványfüggvényekkel).

% Megoldás:
%
%      xi | -2 | -1 | 0 | 1 
%   f(xi) | -1 |  0 | 1 | 0
%
% n = 3, l = 3 => n + l = 6 (dim)
%
% p(x) = a*x^3 + b*x^2 + c*x + d
%
% S3(x) = a*x^3 + b*x^2 + c*x + d + ß1*(x+1)^3+ + ß2*(x-0)^3+
% S3"(x) = 6*a*x + 2*b + 6*ß1*(x+1)+ + 6*ß2*(x-0)+
%------------------------------------------------------------------
% S3(-2) = -8*a + 4*b - 2*c + d = -1
% S3(-1) = -a + b - c + d = 0
% S3(0) = d + ß1 = 1
% S3(1) = a + b + c + d + 8*ß1 + ß2 = 0
% S3"(-2) = -12*a + 2*b = 0
% S3"(1) = 6*a + 2*b + 12*ß1 + 6*ß2 = 0
%
% (természetes peremfeltétel : S3"(-2) = 0, S3"(1) = 0 )


x = [-2,-1,0,1];
y = [-1,0,1,0];

A = [-8, 4, -2, 1, 0, 0;
     -1, 1, -1, 1, 0, 0;
     0, 0, 0, 1, 1, 0;
     1, 1, 1, 1, 8, 1;
     -12, 2, 0, 0, 0, 0;
     6, 2, 0, 0, 12, 6];

b = [-1,0,1,0,0,0]';
c=A\b;
p = c(1:4);

xx=linspace(-2, 1, 100);
pp = polyval(p,xx);
s1 = max(xx+1,0).^3;
s2 = max(xx-0,0).^3;
ss = pp + s1*c(5) + s2*c(6);
%yy = cos(xx);
plot(x,y,'o',xx, ss)
legend('adatok', 'spline')

