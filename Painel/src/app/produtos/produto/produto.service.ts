import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

import { environment } from '../../../environments/environment';
import { Produto } from './produto';
import { BaseService } from '../../core/base/base.service';

@Injectable()
export class ProdutoService extends BaseService<Produto> {
    constructor(private httpClient: HttpClient) {
        super(httpClient, environment.produto);
    }
}