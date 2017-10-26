import { Injectable } from '@angular/core';
import { Observable } from "rxjs/Observable";
import 'rxjs/add/observable/throw';
import { Response } from '@angular/http';

@Injectable()
export class CommonService {
    private baseAuthUrl = 'http://localhost:22524/api';
    private baseMasterUrl = 'http://localhost:25363/api';

    constructor() { }

    getBaseAuthUrl(): string {
        return this.baseAuthUrl;
    }
    getBaseMasterUrl(): string {
        return this.baseMasterUrl;
    }
    handleFullError(error: Response) {
        return Observable.throw(error);
    }

    handleError(error: Response): Observable<any> {
        let errorMessage = error.json();
        console.error(errorMessage);
        return Observable.throw(errorMessage.error || 'Server error');
    }
}