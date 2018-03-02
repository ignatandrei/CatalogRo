import { Injectable } from '@angular/core';
import {
  HttpEvent, HttpInterceptor, HttpHandler, HttpRequest
} from '@angular/common/http';

import { Observable } from 'rxjs/Observable';

/** Pass untouched request through to the next request handler. */
@Injectable()
export class NoCacheInterceptor implements HttpInterceptor {

  intercept(req: HttpRequest<any>, next: HttpHandler):
    Observable<HttpEvent<any>> {
    //var time = Observable.interval(2000).take(1);
    //const nextReq = req.clone({
    //  headers: req.headers.set('Cache-Control', 'no-store, no-cache')
    //    .set('Pragma', 'no-cache')
    //    .set('Expires', 'Sat, 01 Jan 2000 00:00:00 GMT')
    //    .set('If-Modified-Since', '0')
    //});
    let newUrl = req.url;
    if (req.method.toLowerCase() == 'get') {      
      if (newUrl.indexOf('?') > -1) {

        newUrl += "&dt=" + Date.now().toString();
      }
      else {
        newUrl += "?dt=" + Date.now().toString();
      }
      
    }
    const nextReq = req.clone({
      url: newUrl
    });
    var ret = next.handle(nextReq);
    return ret;//.delay(5000);
    
  }
}
