import { useEffect, useState } from "react";
import "./App.css";
import axios from "axios";
import { Header, List } from "semantic-ui-react";

function App() {
  const [cookies, setCookiemanager] = useState<any>([]);

  const token =
    "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9lbWFpbGFkZHJlc3MiOiJ3cml0ZXJAZXhhbXBsZS5jb20iLCJodHRwOi8vc2NoZW1hcy5taWNyb3NvZnQuY29tL3dzLzIwMDgvMDYvaWRlbnRpdHkvY2xhaW1zL3JvbGUiOiJXcml0ZXIiLCJleHAiOjE3MjA3ODk0NTMsImlzcyI6Imh0dHBzOi8vbG9jYWxob3N0OjUwMDAiLCJhdWQiOiJodHRwczovL2xvY2FsaG9zdDo1MDAwIn0.7a259qwA86CWcbWHi_sGhcfIrloVJ-BLCy6WgEWmotU";
  const config = {
    headers: { Authorization: `Bearer ${token}` },
  };

  useEffect(() => {
    axios.get("https://localhost:5000/api/Cookies", config).then((response) => {
      setCookiemanager(response.data);
    });
  }, []);

  return (
    <div>
      <Header as="h2" icon="users" content="Cookie Manager" />
      <List>
        {cookies.map((cookie: any) => (
          <List.Item key={cookie.id}>
            {cookie.name}
            <br />
            <img src={cookie.cookieImageUrl} alt="" width={500} height={500} />
          </List.Item>
        ))}
      </List>
    </div>
  );
}

export default App;
