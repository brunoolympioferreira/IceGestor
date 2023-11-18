export class LocalStorageUtils {
    public obterNomeUsuario() {
        return JSON.parse(localStorage.getItem('icegestor.username'));
    }

    public salvarDadosLocaisUsuario(response: any) {
        this.salvarTokenUsuario(response.token);
        this.salvarNomeUsuario(response.nome);
    }

    public limparDadosLocaisUsuario() {
        localStorage.removeItem('icegestor.token');
        localStorage.removeItem('icegestor.user');
    }

    public obterTokenUsuario(): string {
        return localStorage.getItem('icegestor.token');
    }

    public salvarTokenUsuario(token: string) {
        localStorage.setItem('icegestor.token', token);
    }

    public salvarNomeUsuario(userName: string) {
        localStorage.setItem('icegestor.userName', JSON.stringify(userName));
    }
}