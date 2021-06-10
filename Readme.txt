0.Add this code in your WebJugueteria.csproj.user file:
<Target Name="CopyRoslynFiles" AfterTargets="AfterBuild" Condition="!$(Disable_CopyWebApplication) And '$(OutDir)' != '$(OutputPath)'">
    <ItemGroup>
      <RoslynFiles Include="$(CscToolPath)\*" />
    </ItemGroup>
    <MakeDir Directories="$(WebProjectOutputDir)\bin\roslyn" />
    <Copy SourceFiles="@(RoslynFiles)" DestinationFolder="$(WebProjectOutputDir)\bin\roslyn" SkipUnchangedFiles="true" Retries="$(CopyRetryCount)" RetryDelayMilliseconds="$(CopyRetryDelayMilliseconds)" />
</Target>
1.Restaurar nugets de la solución y compilarla.
2.Configurar Solución WebJugueteria con los dos proyectos de inicio multiple con acción iniciar.
3.Configurar en Web.Config del proyecto ApiJugueteria la llave connectionStrings de la maquina donde se ejecuta el codigo.
4.Iniciar la solución, y esperar que por medio de CodeFirts genere la BD correspondiente.