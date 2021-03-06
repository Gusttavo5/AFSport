import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { BaseService } from '../../core/base/base.service';
import { Estado } from './estado';
import { environment } from '../../../environments/environment';
import { Observable } from 'rxjs';

@Injectable()
export class EstadoService extends BaseService<Estado> {
    constructor(private httpClient: HttpClient) {
        super(httpClient, environment.estado);
    }

    listarAtivos(): Observable<Estado[]> {
        return this.http.get<Estado[]>(environment.estado);
    }
}