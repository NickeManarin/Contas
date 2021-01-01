import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})

export class HomeComponent {
  public contas: Conta[];
  public nome: string;
  public valor: number;
  public vencimento: Date;
  public pagamento: Date;

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) {
    this.list();
  }

  list() {
    this.http.get<Conta[]>(this.baseUrl + 'api/v1/contas').subscribe(result => {
      this.contas = result;
    }, error => console.error(error));
  }
  
  submit() {
    if (this.nome == null || this.nome.length === 0)
      return;

    if (this.valor == null || this.valor <= 0)
      return;

    if (this.vencimento == null || new Date(this.vencimento).getFullYear() < 2010)
      return;

    if (this.pagamento == null || new Date(this.pagamento).getFullYear() < 2010)
      return;
    
    this.http.post(this.baseUrl + 'api/v1/contas/create', { 'Nome': this.nome, 'Valor': this.valor, 'Vencimento': new Date(this.vencimento), 'Pagamento': new Date(this.pagamento) }).subscribe(result => {
      this.nome = '';
      this.valor = 0;
      this.vencimento = new Date();
      this.pagamento = new Date();
      
      this.list();
    }, error => {
        console.error(error);
        alert(error);
    });
  }
}

interface Conta {
  nome: string;
  vencimento: Date;
  pagamento: Date;
  valor: number;
  valorAjustado: number;
  diasDeAtraso: number;
}
