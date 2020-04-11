import { Injectable } from '@angular/core';
import {
  HttpEvent, HttpInterceptor, HttpHandler, HttpRequest
} from '@angular/common/http';

import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';

@Injectable()
export class EnsureHttpsInterceptor implements HttpInterceptor {
  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    
    if (req.url.indexOf('api/') === -1) {   //If the call is not an api request...
        return next.handle(req); // do nothing
    }

    //Get value of api since enviroment
    var origReq = req.clone({ url: `${environment.api_url}${req.url}` });

    // clone request and replace 'http://' with 'https://' at the same time
    //const secureReq = origReq.clone({ url: origReq.url.replace('http://', 'https://') }); 
    const secureReq = origReq;

    // send the cloned, "secure" request to the next handler.
    return next.handle(secureReq);
  }
}


/*
Copyright 2017-2018 Google Inc. All Rights Reserved.
Use of this source code is governed by an MIT-style license that
can be found in the LICENSE file at http://angular.io/license
*/