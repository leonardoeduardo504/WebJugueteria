1.Restaurar nugets de la solución y compilarla.

2.Add this code in your WebJugueteria.csproj.user file:
<Target Name="CopyRoslynFiles" AfterTargets="AfterBuild" Condition="!$(Disable_CopyWebApplication) And '$(OutDir)' != '$(OutputPath)'">
    <ItemGroup>
      <RoslynFiles Include="$(CscToolPath)\*" />
    </ItemGroup>
    <MakeDir Directories="$(WebProjectOutputDir)\bin\roslyn" />
    <Copy SourceFiles="@(RoslynFiles)" DestinationFolder="$(WebProjectOutputDir)\bin\roslyn" SkipUnchangedFiles="true" Retries="$(CopyRetryCount)" RetryDelayMilliseconds="$(CopyRetryDelayMilliseconds)" />
</Target>

3.Configurar Solución WebJugueteria con los dos proyectos de inicio multiple con acción iniciar.

4.Configurar en Web.Config del proyecto ApiJugueteria la llave connectionStrings de la maquina donde se ejecuta el codigo.

5.Iniciar la solución, y esperar que por medio de CodeFirts genere la BD correspondiente.