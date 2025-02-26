import { HttpInterceptorFn } from '@angular/common/http';

export const apiKeyInterceptor: HttpInterceptorFn = (req, next) => {


  req = req.clone({
    setHeaders: {
    'xapikey' : `nCSz8vg4if3TAH5IbVkRrbPWikEbf88c`
    }
  });

  console.log(req);

  return next(req);
};
