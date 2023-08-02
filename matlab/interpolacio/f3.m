% Írja fel az f(x) = cos(pi/2*x) + cos(pi*x) - sin(pi*x) függvényt 
% a -2, -1, 0, 1, 2 alappontokon interpoláló periodikus peremfeltételű
% harmadfokú spline-t! (Javasolt globális bázisban)


% Megoldás:
%
%      xi | -2 | -1 | 0 |  1 | 2
%   f(xi) | 0  | -1 | 2 | -1 | 0
%
% n = 4, l = 3 => n + l = 7 (dim)
%
% p(x) = a*x^3 + b*x^2 + c*x + d
%
% S3(x) = a*x^3 + b*x^2 + c*x + d + ß1*(x+1)^3+ + ß2*(x-0)^3+ + ß3*(x-1)^3+
% S3'(x) = 3*a*x^2 + 2*b*x + c + 3*ß1*(x+1)^2+ + 3*ß2*(x-0)^2+ + 3*ß3*(x-1)^2+
% S3"(x) = 6*a*x + 2*b + 6*ß1*(x+1)+ + 6*ß2(x-0)+ + 6*ß3*(x-1)+
%---------------------------------------------------------------------------------
% S3(-2) = -8a + 4*b - 2*c + d = 0
% S3(-1) = -a + b - c + d = -1
% S3(0) = d + ß1 = 2
% S3(1) = a + b + c + d + 8*ß1 + ß2 = -1
% S3(2) = 8*a + 4*b + 2*c + d + 27*ß1 + 8*ß2 + ß3 = 0
% S3'(-2) = 12*a - 4*b + c = 12*a + 4*b + c + 27*ß1 + 12*ß2 + 3*ß3 = S3'(2)
% => 8*b + 27*ß1 + 12*ß2 + 3*ß3 = 0
% S3"(-2) = -12*a + 2*b = 12*a + 2*b + 18*ß1 + 12*ß2 + 6*ß3 = S3"(2)
% => 24*a + 18*ß1 + 12*ß2 + 6*ß3 = 0
%
% (periodikus peremfeltétel : S3'(-2) = S3'(2), S3"(-2) = S3"(2) )


x = [-2, -1, 0, 1, 2];
y = [0, -1, 2, -1, 0];

A = [-8, 4, -2, 1, 0, 0, 0;
     -1, 1, -1, 1, 0, 0, 0;
     0, 0, 0, 1, 1, 0, 0;
     1, 1, 1, 1, 8, 1, 0;
     8, 4, 2, 1, 27, 8, 1;
     0, 8, 0, 0, 27, 12, 3;
     24, 0, 0, 0, 18, 12, 6;];

b = [0, -1, 2, -1, 0, 0, 0]';

c = A\b;
p = c(1:4);
xx = linspace(-2,2,101);
pp = polyval(p,xx);
s1 = max(0,xx+1).^3;
s2 = max(0,xx-0).^3;
s3 = max(0,xx-1).^3;
ss = pp + c(5)*s1 + c(6)*s2 + c(7)*s3;

yy = cos(pi/2*xx) + cos(pi*xx) - sin(pi*xx);

subplot(2,1,1)
plot(x,y,'o',xx,yy,xx,ss);
legend('adatok','fv', 'spline')

hh = yy - ss;
hiba = norm(hh, "inf");
disp(hiba)

subplot(2,1,2)
plot(xx,hh)
legend('hibafv')
